using RabbitMQ.Client.Events;

namespace Task1.RabbitMQ.Consumer;

public interface IRabbitMQConsumer
{
    void ConsumeProductMessage();
}