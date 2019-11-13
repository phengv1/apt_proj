using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using SystemLibraryData.DAL;
using System.Linq;
using SystemLibraryData.RabbitMq;
using System;

namespace SystemLibraryData
{
    public class AppointmentData : IPatient
    {
        string sql = "";
        Doctor doctor = new Doctor();
        Appointment appointment = new Appointment();
        private GetConnString getConnString = new GetConnString();
        Directmessages dirMsg = new Directmessages();
        Log log = new Log();


        public List<Fee> GetDocFee(int id)
        {
            
            string sql = "Select * from Fee where DId = @DId";

            using (var con = new SqlConnection(getConnString.getString()))
            {
                try
                {
                    var output = con.Query<Fee>(sql, new { @DId = id }).AsList();
                    
                    return output;
                }
                catch (System.Exception ex)
                {
                    
                    return null;
                }
            }
        }
        public List<Appointment> GetAppointmentData()
        {
            log.Action = "GetAppointmentData";
            log.Message = "Select all data from appointment  ChargeDetail  Doctor  Card ";
            log.Date = DateTime.Now;
            log.Exception = "";

            string sql = "Select a.ApId, a.PId, CNo, ApDate, ApStatus, ChId, SpId, ChFee, ChStatus, d.DId, DName, DTel, DSex, DFee, DStatus from appointment a, ChargeDetail ch, Doctor d, Card c where a.ApId = ch.ApId and a.DId=d.DId and a.PId = c.PId";

            using (var con = new SqlConnection(getConnString.getString()))
            {
                try
                {
                    var output = con.Query<Appointment, Doctor, Appointment>(sql, (appointment, doctor) => { appointment.Doctor = doctor; return appointment; }, splitOn: "DId").AsList();

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
        public bool MakeAppointmentData(Appointment appointment)
        {
            if (CheckCardNo(appointment.CNo))
            {
                log.Action = "MakeAppointmentData";
                log.Message = "Insert into Appointment DId: " + appointment.DId + ", ApDate: " + appointment.ApDate + ". Update Doctor table set DQueue = -1";
                log.Date = DateTime.Now;
                log.Exception = "";

                DoctorDataHandler doc = new DoctorDataHandler();

                var docQ = doc.GetDoctorData<Doctor>().Where(q => q.DId == appointment.Doctor.DId);
                var chkQ = false;
                var chkStatus = false;

                foreach (var item in docQ)
                {
                    if (item.DApQueue > 0)
                    {
                        chkQ = true;
                    }

                    if (item.DStatus == 1)
                    {
                        chkStatus = true;
                    }
                }

                if (chkQ == true && chkStatus == true)
                {
                    using (var con = new SqlConnection(getConnString.getString()))
                    {

                        con.Open();
                        using (var trans = con.BeginTransaction())
                        {
                            sql = "Insert into Appointment(DId, PId, ApDate) values(@DId, (Select p.PId from patient p, card c where CNo = @CNo and p.PId=c.PId), @date)";

                            con.Execute(sql, new { @DId = appointment.Doctor.DId, @date = appointment.ApDate, @CNo = appointment.CNo }, trans);

                            try
                            {
                                sql = "Insert into ChargeDetail(ApId, SpId, ChFee) values((SELECT MAX(ApId) FROM Appointment), (Select SpId from ServiceProvider where SpUsername = @usr), @ChFee)";

                                con.Execute(sql, new { @ChFee = appointment.ChFee, @usr = appointment.SpUsername }, trans);


                                sql = "Update Doctor set DApQueue = DApQueue - 1 where DId = @Id";

                                con.Execute(sql, new { @Id = appointment.Doctor.DId }, transaction: trans);

                                dirMsg.SendMessage(log);

                                trans.Commit();

                                return true;
                            }
                            catch (System.Exception ex)
                            {
                                log.Exception = ex.ToString();
                                dirMsg.SendMessage(log);

                                trans.Rollback();

                                return false;
                            }
                        }

                    }
                }
                else
                {
                    return false;
                }

            }
            else return false;
             
        }

        public bool UpdateChargeStatusData(Appointment appointment)
        {
            log.Action = "UpdateChargeStatusData";
            log.Message = "Update ChargeDetail table set ChStatus: " + appointment.ChStatus + ", ChFee: " + appointment.ChFee + " where ApId: " + appointment.ApId;
            log.Date = DateTime.Now;
            log.Exception = "";

            var dq = Query<Doctor>().Where(qn => qn.DId == appointment.DId);
            int q = 0;
            string op = "";

            if (appointment.ChStatus == 0) op = "+";
            else op = "-";

            foreach (var item in dq)
            {
                q = item.DApQueue;
            }
            if (q > 0 || appointment.ChStatus == 0)
            {
                using (var con = new SqlConnection(getConnString.getString()))
                {

                    try
                    {
                        sql = "Update ChargeDetail set ChStatus = @Status, ChFee = @Fee where ApId = @id";

                        con.Execute(sql, new { @Status = appointment.ChStatus, @id = appointment.ApId, @Fee = appointment.ChFee });


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
            else return false;
        }

        public bool UpdateAptStatusData(Appointment appointment)
        {
            log.Action = "UpdateAptStatusData";
            log.Message = "Update Appointment table set ApStatus: " + appointment.ApStatus + " where ApId: " + appointment.ApId + ". Update Doctor table set DQueue = +1";
            log.Date = DateTime.Now;
            log.Exception = "";

            using (var con = new SqlConnection(getConnString.getString()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    sql = "Update Appointment set ApStatus = @Status where ApId = @id";

                    con.Execute(sql, new { @Status = appointment.ApStatus, @id = appointment.ApId }, trans);

                    try
                    {
                        sql = "Update Doctor set DApQueue = DApQueue + 1 where DId = @Id";
                        con.Execute(sql, new { Id = appointment.DId }, transaction: trans);

                        dirMsg.SendMessage(log);

                        trans.Commit();
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        log.Exception = ex.ToString();
                        dirMsg.SendMessage(log);

                        trans.Rollback();
                        return false;
                    }

                }

            }

        }

        public bool CheckCardNo(string id)
        {
            string sql = "Select * from Card where CNo = @CNo";

            using (var con = new SqlConnection(getConnString.getString()))
            {

                try
                {
                    var output = con.Query<Card>(sql, new { @CNo = id }).AsList();

                    if (output.Count != 0)
                    {
                        return true;
                    }
                    else return false;
                }
                catch (Exception)
                {

                    return false;
                }
                

            }
        }

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
            string sql = "Select * from Doctor";

            using (var con = new SqlConnection(getConnString.getString()))
            {
                var output = con.Query<T>(sql).AsList();

                return output;
            }
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}