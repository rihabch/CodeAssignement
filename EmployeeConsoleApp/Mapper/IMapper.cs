using System;
using EmployeeConsoleApp.Database;
using Models = EmployeeAPI.Shared.Models;

namespace EmployeeConsoleApp.Mapper
{
    //we don't need the mapper, just added it in case we had more complicated objects
    public interface IMapper
    {
        Employee ToDBEntity(Models.Employee employee);
        Models.Employee ToMessagingModel(Employee employee);
    }
}
