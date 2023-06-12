using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Task1.RabbitMQ.Consumer;

public class RabbitMQConsumer : IRabbitMQConsumer
{
    public event EventHandler<BasicDeliverEventArgs> MessageDeliveryEventHandler;

    public void ConsumeProductMessage()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        var connection = factory.CreateConnection();
        
        using var channel = connection.CreateModel();
        channel.QueueDeclare("product", exclusive: false);
        
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += MessageDeliveryEventHandler;
        
        channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
    }
}