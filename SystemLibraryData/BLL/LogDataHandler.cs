using System.Collections.Generic;

namespace SystemLibraryData
{
    public class LogDataHandler
    {
        LogData LogData = new LogData();
        public List<T> GetLogDataHandler<T>()
        {
            return LogData.GetLogData<T>();
        }
    }
}