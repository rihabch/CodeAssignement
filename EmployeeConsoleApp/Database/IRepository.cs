using System;

namespace EmployeeConsoleApp.Database
{
    public interface IRepository : IDisposable
    {
        Employee GetEmployeeByID(Guid studentId);
        Guid InsertEmployee(Employee student);
        void Save();
    }
}
