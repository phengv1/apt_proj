using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SystemLibraryData.DAL;
using SystemLibraryData.RabbitMq;

namespace SystemLibraryData
{
    public class DoctorData : IPatient
    {
        private GetConnString getConnString = new GetConnString();
        Directmessages dirMsg = new Directmessages();
        string sql = "";
        Log log = new Log();

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert<T>(T data)
        {
            throw new System.NotImplementedException();
        }

        public List<T> Query<T>()
        {
            log.Action = "Query";
            log.Message = "Select all data from Doctor table ";
            log.Date = DateTime.Now;
            log.Exception = "";

            string sql = "Select * from Doctor";


            using (var con = new SqlConnection(getConnString.getString()))
            {
                try
                {
                    var output = con.Query<T>(sql).AsList();

                    //dirMsg.SendMessage(log);

                    return output;
                }
                catch (System.Exception ex)
                {
                    //log.Exception = ex.ToString();
                    ////dirMsg.SendMessage(log);

                    return null;
                }
            }
        }

        public bool UpdateDoctorData(Doctor doc)
        {
            log.Action = "UpdateDoctorData";
            log.Message = "Update Doctor table set DStatus: "+doc.DStatus+", DApQueue: "+doc.DApQueue+" where DId: "+ doc.DId;
            log.Date = DateTime.Now;
            log.Exception = "";

            string sql = "Update Doctor set DStatus = @status, DApQueue = @q where DId = @id";

            using (var con = new SqlConnection(getConnString.getString()))
            {

                try
                {
                    var output = con.Execute(sql, new { @status = doc.DStatus, @q = doc.DApQueue, @id = doc.DId });

                    dirMsg.SendMessage(log);

                    return true;
                }
                catch (System.Exception ex)
                {
                    log.Exception = ex.ToString();
                    dirMsg.SendMessage(log);

                    return false;
                }

            }
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}