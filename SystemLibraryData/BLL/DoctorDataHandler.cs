using System.Collections.Generic;

namespace SystemLibraryData
{
    public class DoctorDataHandler
    {
        DoctorData doctorData = new DoctorData();

        public List<T> GetDoctorData<T>()
        {

            return doctorData.Query<T>();
        }

        public bool UpdateDoctorDataHandler(Doctor doc)
        {
            return doctorData.UpdateDoctorData(doc);
        }
    }
}