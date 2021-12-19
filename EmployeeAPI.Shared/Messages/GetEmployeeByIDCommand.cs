using System;
using EmployeeApi.Shared.Messages;

namespace EmployeeAPI.Shared.Messages
{
    public class GetEmployeeByIDCommand : ICommand
    {
        public Guid EmployeeID { get; set; } 

        public GetEmployeeByIDCommand(Guid employeeID)
        {
            EmployeeID = employeeID;

        }
    }
}
