using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SystemLibraryData.DAL;
using SystemLibraryData.RabbitMq;

namespace SystemLibraryData
{
    public class PatientData : IPatient
    {
        //private readonly string connectionString;

        //public PatientData(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}
        private GetConnString getConnString = new GetConnString();
        string sql = "";
        Patient p = new Patient();  
 
        Log log = new Log();
        Directmessages dirMsg = new Directmessages();

        public List<T> Query<T>()
        {
            log.Action = "Query";
            log.Message = "Select all data from Patient and Card table.";
            log.Date = DateTime.Now;
            log.Exception = "";

            p.CardInfo = new Card();
            
            using (var con = new SqlConnection(getConnString.getString()))
            {
                 
                try
                {
                    //Get Data
                    var output = con.Query<T>("Select * from Patient p, Card c where p.PId=c.PId").AsList();


                    //dirMsg.SendMessage(log);

                    return output;
                }
                catch (System.Exception ex)
                {
                    //log.Exception = ex.ToString();

                    //dirMsg.SendMessage(log);

                    return null;
                }
            }

        }
        public bool AddNewPatient(Patient data)
        {
            Log log = new Log();

            log.Action = "AddNewPatient";
            log.Message = "Insert into  Patient table PName: "+ data.PName+ ", PTel: "+data.PTel+", PDocumentNo: "+data.PDocumentNo+"  and CNo:"+data.CardInfo.CNo+" to Card table ";
            log.Date = DateTime.Now;
            log.Exception = "";

            var pList = Query<Patient>();
            
            foreach (var item in pList)
            {
                if (item.CNo == data.CardInfo.CNo)
                {
                    
                    return false;
                }
            }

            using (var con = new SqlConnection(getConnString.getString()))
            {
                
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    sql = "Insert into Patient(PName, PTel, PSex, PAddress, PDocumentNo) values(@PName, @PTel, @PSex, @PAddress, @PDocumentNo)";

                    con.Execute(sql, data, trans);

                    try
                    {
                        sql = "Insert into Card(CNo, PId) values(@CNo, (SELECT MAX(PId) FROM Patient))";

                        con.Execute(sql, new { data.CardInfo.CNo }, transaction: trans);


                        dirMsg.SendMessage(log);

                        trans.Commit();

                        return true;
                    }
                    catch (System.Exception ex)
                    {

                        trans.Rollback();

                        log.Exception = ex.ToString();
                        dirMsg.SendMessage(log);

                        return false;
                    }
                }


            }
        }

        public bool Delete(int id)
        {
            log.Action = "Delete";
            log.Message = "Delete PId: "+id+" from Patient table.  ";
            log.Date = DateTime.Now;
            log.Exception = "";

            using (var con = new SqlConnection(getConnString.getString()))
            {

                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    sql = "Delete from Patient where PId = @PId";

                    con.Execute(sql, new { @PId = id }, trans);

                    try
                    {
                        sql = "Delete from Card where PId = @PId";

                        con.Execute(sql, new { @PId = id }, transaction: trans);

                        dirMsg.SendMessage(log);

                        trans.Commit();

                        return true;
                    }
                    catch (System.Exception ex)
                    {

                        trans.Rollback();

                        log.Exception = ex.ToString();
                        dirMsg.SendMessage(log);

                        return false;
                    }
                }
                
            }
        }

        public bool UpdatePatientInfo(Patient p)
        {
            log.Action = "UpdatePatientInfo";
            log.Message = "Update  Patient table set PName: "+p.PName+", PSex: "+p.PSex+", PTel: "+p.PTel+", PAddress: "+p.PAddress+", PDocumentNo: "+p.PDocumentNo+" where PId: " + p.PId+ ". Update Card table set CNo: " + p.CardInfo.CNo+"  where PId: "+p.PId+"";
            log.Date = DateTime.Now;
            log.Exception = "";

            using (var con = new SqlConnection(getConnString.getString()))
            {

                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    sql = "Update Patient set PName = @PName, PSex = @PSex, PTel = @PTel, PAddress = @PAddress, PDocumentNo = @PDocumentNo where PId = @PId";

                    con.Execute(sql, new { @PName = p.PName, @PSex = p.PSex, @PTel = p.PTel, @PAddress = p.PAddress, @PDocumentNo = p.PDocumentNo, @PId = p.PId }, trans);

                    try
                    {
                        sql = "Update Card set CNo = @CNo where PId = @PId";

                        con.Execute(sql, new { @PId = p.PId, @CNo = p.CardInfo.CNo }, transaction: trans);


                        dirMsg.SendMessage(log);

                        trans.Commit();

                        return true;
                    }
                    catch (System.Exception ex)
                    {

                        trans.Rollback();

                        log.Exception = ex.ToString();
                        dirMsg.SendMessage(log);

                        return false;
                    }
                }

            }
        }

        public bool LoginUser(ServiceProvider serviceProvider)
        {
            log.Action = "LoginUser";
            log.Message = "Login User where SpUsername: "+serviceProvider.SpUsername;
            log.Date = DateTime.Now;
            log.Exception = "";

            ServiceProvider sp = new ServiceProvider();

            using (var con = new SqlConnection(getConnString.getString()))
            {
                sql = "Select * from ServiceProvider where SpUsername = @user and SpPassword = @pw";

                try
                {
                    var output = con.Query<ServiceProvider>(sql, new { @user = serviceProvider.SpUsername, @pw = serviceProvider.SpPassword }).AsList();

     
                    dirMsg.SendMessage(log);


                    if (output.Count > 0)
                    {

                        return true;
                    }
                    else return false;
                }
                catch (System.Exception ex)
                {
                    log.Exception = ex.ToString();
                    dirMsg.SendMessage(log);

                    return false;
                }
            }
        }

        public void LogoutUser(string name)
        {
            log.Action = "LogoutUser";
            log.Message = "User: "+name+" has logged out.";
            log.Date = DateTime.Now;
            log.Exception = "";

            dirMsg.SendMessage(log);
        }

        public void Insert<T>(T data)
        {
            
            
            
        }

        
        public void Update()
        {
            throw new System.NotImplementedException();
        }


    }
}