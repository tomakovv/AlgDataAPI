using AlgorithmAPI.Client;
using CalculationAPI.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CalculationAPI.Calculation.Messaging.Receive;

public class CalculationReceiver : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;
    private readonly IServiceScopeFactory _scopeFactory;

    public CalculationReceiver(IServiceScopeFactory scopeFactory)
    {
        CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "CalculationQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        _scopeFactory = scopeFactory;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (sender, ea) =>
        {
            var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            var calculation = JsonConvert.DeserializeObject<DataSetRead>(content);
            HandleCalculation(calculation);
            _channel.BasicAck(ea.DeliveryTag, false);
        };
        _channel.BasicConsume("CalculationQueue", autoAck: false, consumer: consumer);
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

    private void HandleCalculation(DataSetRead data)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var calculationService = scope.ServiceProvider.GetRequiredService<ICalculationService>();
            calculationService.CalculateData(data);
        }
    }
}