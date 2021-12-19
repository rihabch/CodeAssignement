using System;
using EmployeeAPI.Shared.Messages;
using EmployeeConsoleApp.Database;
using Microsoft.Extensions.Logging;

namespace EmployeeConsoleApp.EmployeeService
{
    public interface IEmployeeService
    {
        Guid CreateNewEmployee(CreateEmployeeCommand cmd, ILogger logger);
        Employee GetEmployeeByid(GetEmployeeByIDCommand cmd, ILogger logger);
    }
}
