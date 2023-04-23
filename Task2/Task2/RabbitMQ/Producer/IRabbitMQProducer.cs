namespace Task2.RabbitMQ.Producer;

public interface IRabbitMQProducer
{
    void SendProductMessage<T>(T message);
}