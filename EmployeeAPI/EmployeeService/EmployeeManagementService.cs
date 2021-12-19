using System;
using EmployeeAPI.EmployeeSender;
using EmployeeAPI.Shared.Messages;
using EmployeeAPI.Shared.Models;

namespace EmployeeAPI.EmployeeService
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        private readonly IEmployeeSender _employeeSender;

        public EmployeeManagementService(IEmployeeSender employeeSender)
        {
            //initialize queue here
            _employeeSender = employeeSender;

        }

        public void CreateNewEmployee(Guid employeeID, string firstName, string lastName, string city, int socialSecurityNumber)
        {
            var createEmployeeCommand = new CreateEmployeeCommand(employeeID, firstName, lastName, city, socialSecurityNumber);
            //publish to queue here
            _employeeSender.PublishMessage(createEmployeeCommand);
        }

        public void GetEmployeeByID(Guid employeeID)
        {
            var getEmployeeByIDCommand = new GetEmployeeByIDCommand(employeeID);
            //publish to queue here
            _employeeSender.PublishMessage(getEmployeeByIDCommand);
        }
    }
}
