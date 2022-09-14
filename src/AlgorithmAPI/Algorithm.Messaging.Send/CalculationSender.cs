using AlgorithmAPI.Client;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AlgorithmAPI.Algorithm.Messaging.Send
{
    public class CalculationSender : ICalculationSender
    {
        private IConnection _connection;

        public CalculationSender()
        {
            CreateConnection();
        }

        public void SendCalculation(DataSetRead data)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CalculationQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    var json = JsonConvert.SerializeObject(data);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: "CalculationQueue", basicProperties: null, body: body);
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