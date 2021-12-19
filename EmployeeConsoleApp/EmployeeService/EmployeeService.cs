using System;
using EmployeeAPI.Shared.Messages;
using EmployeeConsoleApp.Database;
using EmployeeConsoleApp.Validation;
using Microsoft.Extensions.Logging;

namespace EmployeeConsoleApp.EmployeeService
{
    public class EmployeesService : IEmployeeService
    {
        private readonly IRepository _employeeRepository;
        public EmployeesService()
        {
            _employeeRepository = new Repository(new EmploymentDBContext());
        }

        public Guid CreateNewEmployee(CreateEmployeeCommand cmd, ILogger logger) {

            var newEmployee = new Employee(
               employeeID: cmd.EmployeeID,
               firstName: cmd.FirstName,
               lastName: cmd.LastName,
               city: cmd.City,
               socialSecurityNumber: cmd.SocialSecurityNumber
               );


            //verify the info received from the command
            Verify.VerifyEmployee(newEmployee, logger);

            //insert into database
            return _employeeRepository.InsertEmployee(newEmployee);
        }

        public Employee GetEmployeeByid(GetEmployeeByIDCommand cmd, ILogger logger) {
            // query database for employee with specified ID
            return _employeeRepository.GetEmployeeByID(cmd.EmployeeID);

        }
    }
}
