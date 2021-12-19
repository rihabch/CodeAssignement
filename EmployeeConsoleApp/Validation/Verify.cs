using EmployeeConsoleApp.Database;
using Microsoft.Extensions.Logging;

namespace EmployeeConsoleApp.Validation
{
    public static class Verify
    {

        public static bool VerifyEmployee(Employee employee, ILogger logger)
        {
            if (employee == null) {
                logger.LogError("Employee is empty");
                return false;
            }
            
            if (string.IsNullOrEmpty(employee.FirstName))
            {
                logger.LogError("Employee's first name is empty");
                return false;
            }

            if (string.IsNullOrEmpty(employee.LastName))
            {
                logger.LogError("Employee's last name is empty");
                return false;
            }

            if (string.IsNullOrEmpty(employee.City))
            {
                logger.LogError("Employee's city is empty");
                return false;
            }

            if (LuhnAlgorithm.Check(employee.SocialSecurityNumber.ToString()))
            {
                logger.LogError("Employee's social security number is invalid");
                return false;
            }
            return true;
        }
    }
}
