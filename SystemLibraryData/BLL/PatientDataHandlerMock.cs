using System;
using System.Collections.Generic;
using System.Text;

namespace SystemLibraryData.BLL
{
    public class PatientDataHandlerMock : IPatientDataHandler
    {
        public bool AddNewPatientData(Patient info)
        {
            return true;
        }

        public bool DeletePatientData(int id)
        {
            return true;
        }

        public bool EditPatientData(Patient info)
        {
            return true;
        }

        public List<T> GetPatientsData<T>()
        {
            return null;
        }

        public bool LoginUserHandler(ServiceProvider serviceProvider)
        {
            return true;
        }

        public void LogoutUserHandler(string name)
        {
         
        }
    }
}
