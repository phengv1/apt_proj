using System;

namespace SystemLibraryData
{
    public class Log
    {
        public int Id
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string Action
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string Exception
        {
            get;
            set;
        }
    }
}