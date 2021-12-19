using System;
using EmployeeApi.Shared.Messages;

namespace EmployeeAPI.Shared.Messages
{
    public class CreateEmployeeCommand : ICommand
    {
        public Guid EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public int SocialSecurityNumber { get; set; }

        public CreateEmployeeCommand(Guid employeeID, string firstName, string lastName, string city, int socialSecurityNumber)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            SocialSecurityNumber = socialSecurityNumber;
        }
    }
}
