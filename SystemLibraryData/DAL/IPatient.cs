using System.Collections.Generic;

namespace SystemLibraryData
{
    public interface IPatient
    {
        List<T> Query<T>();
        void Insert<T>(T data);
        void Update();
        bool Delete(int id);
    }
}