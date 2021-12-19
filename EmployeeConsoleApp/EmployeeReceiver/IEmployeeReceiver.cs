using System;
using EmployeeAPI.Shared.Messages;

namespace EmployeeConsoleApp.EmployeeReceiver
{
    public interface IEmployeeReceiver
    {
        void ListenToMessage();
    }
}
