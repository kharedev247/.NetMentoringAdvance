namespace Task1.RabbitMQ.Producer;

public interface IRabbitMQProducer
{
    void SendProductMessage<T>(T message);
}