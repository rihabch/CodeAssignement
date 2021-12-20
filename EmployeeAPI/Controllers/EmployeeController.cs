using System;
using EmployeeAPI.EmployeeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("[employee]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeManagementService _employeeManagementService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeManagementService employeeManagementService)
        {
            _logger = logger;
            _employeeManagementService = employeeManagementService;
        }

        [HttpGet]
        public void GetEmployeeByID(Guid employeeID)
        {
            _logger.LogInformation("Getting employee with ID : " + employeeID);
            _employeeManagementService.GetEmployeeByID(employeeID);
        }

        [HttpPost]
        public Guid CreateEmployee(string firstName, string lastName, string city, int socialSecurityNumber)
        {
            _logger.LogInformation("Saving new employee to database");
            var employeeID = new Guid();
            _employeeManagementService.CreateNewEmployee(employeeID, firstName, lastName, city, socialSecurityNumber);
            return employeeID;
        }
    }
}
