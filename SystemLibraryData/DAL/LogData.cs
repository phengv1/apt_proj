using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using SystemLibraryData.DAL;

namespace SystemLibraryData
{
    public class LogData
    {
        private GetConnString getConnString = new GetConnString();

        public List<T> GetLogData<T>()
        {
            using (var con = new SqlConnection(getConnString.getString()))
            {
                string sql = "Select * from Log";

                var output = con.Query<T>(sql).AsList();

                return output;
            }
        }
        public void AddLogInfo(string action, string msg, string ex)
        {
            Log log = new Log();

            log.Action = action;
            log.Message = msg;
            log.Exception = ex;

            using (var con = new SqlConnection(getConnString.getString()))
            {
                string sql = "Insert into Log(Action, Message, Exception) values(@Action, @Message, @Exception)";

                // Add Log   
                var chk = con.Execute(sql, log);
            }

        }
    }
}