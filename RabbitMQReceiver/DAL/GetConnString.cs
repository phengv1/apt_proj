using System;
using System.Collections.Generic;
using System.Text;

namespace SystemLibraryData.DAL
{
    class GetConnString
    {
        private readonly string str = "Data Source=.;Initial Catalog=Appointment;Persist Security Info=True;User ID=m;Password=123";
        public string getString()
        {
            return str;
        }
    }
}
