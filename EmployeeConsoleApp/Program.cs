using EmployeeAPI.Shared;
using EmployeeConsoleApp.EmployeeReceiver;
using EmployeeConsoleApp.EmployeeService;
using Microsoft.Extensions.Logging;

namespace EmployeeConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            using ILoggerFactory loggerFactory =
            LoggerFactory.Create(builder =>

            builder.AddSimpleConsole(options =>
            {
                options.IncludeScopes = true;
                options.UseUtcTimestamp = true;
                options.SingleLine = true;
                options.TimestampFormat = "hh:mm:ss ";
            })
            );

            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogInformation("Hej there, just started, logger is working!");

            var config = new RabbitMqConfig(
                  hostname: "localhost",
                queueName: "EmployeeQueue",
                userName: "guest",
                password: "guest");

            var employeesService = new EmployeesService();

            
            logger.LogInformation("Configuring Receiver");

            var employeeReceiver = new EmployeesReceiver(
                employeeService: employeesService,
                rabbitMqConfig: config,
                loggerFactory: loggerFactory);

            logger.LogInformation("Started listening...");

            employeeReceiver.ListenToMessage();
        }

    }
}
