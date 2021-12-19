namespace EmployeeAPI.Shared
{
    public class RabbitMqConfig
    {
        public RabbitMqConfig(string hostname, string queueName, string userName, string password)
        {
            Hostname = hostname;
            QueueName = queueName;
            UserName = userName;
            Password = password;
        }
        public string Hostname { get; set; }

        public string QueueName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
