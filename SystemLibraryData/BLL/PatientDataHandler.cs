using System.Collections.Generic;
using SystemLibraryData.BLL;

namespace SystemLibraryData
{
    public class PatientDataHandler : IPatientDataHandler
    {
        //IPatient data = null;

        //public PatientDataHandler(IPatient patient)
        //{
        //    data = patient;
        //}
        PatientData patientData = new PatientData();
        

        public List<T> GetPatientsData<T>()
        {
            
            return patientData.Query<T>();
        }

        public bool AddNewPatientData(Patient info)
        {
            return patientData.AddNewPatient(info);
        }

        public bool DeletePatientData(int id)
        {
            return patientData.Delete(id);
        }

        public bool EditPatientData(Patient info)
        {
            return patientData.UpdatePatientInfo(info);
        }

        public bool LoginUserHandler(ServiceProvider serviceProvider)
        {
            return patientData.LoginUser(serviceProvider);
        }

        public void LogoutUserHandler(string name)
        {
           patientData.LogoutUser(name);
        }
    }
}