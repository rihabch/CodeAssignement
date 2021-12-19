using System;
using System.Text;
using EmployeeApi.Shared.Messages;
using EmployeeAPI.Shared;
using EmployeeAPI.Shared.Messages;
using EmployeeConsoleApp.EmployeeService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace EmployeeConsoleApp.EmployeeReceiver
{
    public class EmployeesReceiver : IEmployeeReceiver
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger _logger;
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public EmployeesReceiver(
            IEmployeeService employeeService,
            RabbitMqConfig rabbitMqConfig,
            ILoggerFactory loggerFactory)
        {
            _hostname = rabbitMqConfig.Hostname;
            _queueName = rabbitMqConfig.QueueName;
            _username = rabbitMqConfig.UserName;
            _password = rabbitMqConfig.Password;

            _employeeService = employeeService;

            _logger = loggerFactory.CreateLogger<EmployeesReceiver>();

            InitializeRabbitMqListener();
        }

        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void ListenToMessage()
        {
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            int messageCount = Convert.ToInt16(_channel.MessageCount(_queueName));
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var cmd = JsonConvert.DeserializeObject<ICommand>(content);

                HandleMessage(cmd);

                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            _channel.BasicConsume(queue: _queueName,
                                 autoAck: false,
                                 consumer: consumer);

        }

        private void HandleMessage(ICommand cmd)
        {
            switch (cmd.GetType().Name)
            {
                case "CreateEmployeeCommand":
                    HandleMessage(cmd as CreateEmployeeCommand);
                    break;
                case "GetEmployeeByIDCommand":
                    HandleMessage(cmd as GetEmployeeByIDCommand);
                    break;
                default:
                    _logger.LogInformation($"Message is of type {cmd.GetType().Name}.");
                    break;
            }
        }

        private void HandleMessage(CreateEmployeeCommand cmd)
        {
            _logger.LogInformation("Received CreateNewEmployee command");
            _employeeService.CreateNewEmployee(cmd, _logger);
        }

        private void HandleMessage(GetEmployeeByIDCommand cmd)
        {
            _logger.LogInformation("Received GetEmployeeByIDCommand command");
            _employeeService.GetEmployeeByid(cmd, _logger);
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }
    }
}
