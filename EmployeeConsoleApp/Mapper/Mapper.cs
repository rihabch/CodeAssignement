using System;
using EmployeeConsoleApp.Database;
using Models = EmployeeAPI.Shared.Models;

namespace EmployeeConsoleApp.Mapper
{
    //we don't need the mapper, just added it in case we had more complicated objects
    public class Mapper : IMapper
    {

        public Employee ToDBEntity(EmployeeAPI.Shared.Models.Employee employee)
        {
            return new Employee(
                employeeID: employee.EmployeeID,
                firstName: employee.FirstName,
                lastName: employee.LastName,
                city: employee.City,
                socialSecurityNumber: employee.SocialSecurityNumber
                );
        }

        public Models.Employee ToMessagingModel(Employee employee)
        {
            return new Models.Employee(
                employeeID: employee.EmployeeID,
                firstName: employee.FirstName,
                lastName: employee.LastName,
                city: employee.City,
                socialSecurityNumber: employee.SocialSecurityNumber
                );
        }
    }
}
