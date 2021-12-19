using System;

namespace EmployeeAPI.EmployeeService
{
    public interface IEmployeeManagementService
    {
        void CreateNewEmployee(Guid employeeID, string firstName, string lastName, string city, int socialSecurityNumber);

        void GetEmployeeByID(Guid employeeID);
    }
}
