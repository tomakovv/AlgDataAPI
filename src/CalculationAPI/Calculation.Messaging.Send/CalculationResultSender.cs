using RabbitMQ.Client;
using System.Text;

namespace CalculationAPI.Calculation.Messaging.Send
{
    public class CalculationResultSender : ICalculationResultSender
    {
        private IConnection _connection;

        public CalculationResultSender()
        {
            CreateConnection();
        }

        public void SendCalculationResult(string data)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CalculationResultQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    var body = Encoding.UTF8.GetBytes(data);
                    channel.BasicPublish(exchange: "", routingKey: "CalculationResultQueue", basicProperties: null, body: body);
                }
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "rabbitmq"
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}