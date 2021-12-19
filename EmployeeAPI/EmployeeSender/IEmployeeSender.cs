using EmployeeApi.Shared.Messages;

namespace EmployeeAPI.EmployeeSender
{
    public interface IEmployeeSender
    {
        void PublishMessage(ICommand command);
        //void RequestMessage(ICommand command);
    }
}
