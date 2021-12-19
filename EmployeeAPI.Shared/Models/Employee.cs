using System;

namespace EmployeeAPI.Shared.Models
{
    public class Employee
    {
        public Employee(Guid employeeID, string firstName, string lastName, string city, int socialSecurityNumber)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public Guid EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public int SocialSecurityNumber { get; set; }
    }
}
