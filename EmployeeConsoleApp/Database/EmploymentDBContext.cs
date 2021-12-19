using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeConsoleApp.Database
{
    public class EmploymentDBContext : DbContext
    {
        public DbSet<Employee> Employment { get; set; }

        public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EmploymentDB;Trusted_Connection=True;");
    }

    public class Employee
    {

        public Guid EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public int SocialSecurityNumber { get; set; }

        public Employee(Guid employeeID, string firstName, string lastName, string city, int socialSecurityNumber)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            SocialSecurityNumber = socialSecurityNumber;
        }
    }
}
