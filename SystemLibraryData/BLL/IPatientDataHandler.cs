using System;
using System.Collections.Generic;
using System.Text;

namespace SystemLibraryData.BLL
{
    public interface IPatientDataHandler
    {
        bool LoginUserHandler(ServiceProvider serviceProvider);
        List<T> GetPatientsData<T>();
        bool AddNewPatientData(Patient info);
        bool DeletePatientData(int id);
        bool EditPatientData(Patient info);
        void LogoutUserHandler(string name);
    }
}
