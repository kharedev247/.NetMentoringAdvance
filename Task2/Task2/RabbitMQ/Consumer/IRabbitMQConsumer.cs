using RabbitMQ.Client.Events;

namespace Task2.RabbitMQ.Consumer;

public interface IRabbitMQConsumer
{
    void ConsumeProductMessage();
}