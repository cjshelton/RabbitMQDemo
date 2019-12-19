using System;
using Messaging.Contracts;
using Messaging.Producing.Contracts;
using RabbitMQ.Client;
using Utilities.Contracts;

namespace Messaging.Producing
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly ITypeConverter _typeConverter;

        public MessageProducer(IConnectionFactory connectionFactory, ITypeConverter typeConverter)
        {
            if (connectionFactory == null) throw new ArgumentNullException(nameof(connectionFactory));

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _typeConverter = typeConverter;
        }

        public void Produce<T>(Settings settings, IMessage<T> message)
        {
            byte[] data = _typeConverter.ToByteArray(message.Data);

            _channel.BasicPublish(
                exchange: settings.Exchange,
                routingKey: settings.RoutingKey,
                mandatory: settings.Mandatory,
                basicProperties: settings.BasicProperties,
                body: data);
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }
    }
}
