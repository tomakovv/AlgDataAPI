﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AlgorithmAPI.Algorithm.Messaging.Recieve
{
    public class CalculationResultReceiver : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;

        public CalculationResultReceiver()
        {
            CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "CalculationResultQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, ea) =>
            {
                var calculationResult = Encoding.UTF8.GetString(ea.Body.ToArray());
                HandleCalculationResult(calculationResult);
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("CalculationResultQueue", autoAck: false, consumer: consumer);
            return Task.CompletedTask;
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

        private void HandleCalculationResult(string data)
        {
            Console.WriteLine(data);
        }
    }
}