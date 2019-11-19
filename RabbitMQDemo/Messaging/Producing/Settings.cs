using System;
using RabbitMQ.Client;

namespace Messaging.Producing
{
    public class Settings
    {
        public Settings(string exchange, string routingKey)
        {
            Exchange = exchange ?? throw new ArgumentNullException(nameof(exchange));
            RoutingKey = routingKey ?? throw new ArgumentNullException(nameof(routingKey));
        }

        public Settings(string exchange, string routingKey, bool mandatory)
            : this(exchange, routingKey)
        {
            Mandatory = mandatory;
        }

        public Settings(string exchange, string routingKey, IBasicProperties basicProperties)
            : this(exchange, routingKey)
        {
            BasicProperties = basicProperties;
        }

        public Settings(string exchange, string routingKey, bool mandatory, IBasicProperties basicProperties)
            : this(exchange, routingKey, mandatory)
        {
            BasicProperties = basicProperties ?? throw new ArgumentNullException(nameof(basicProperties));
        }

        public string Exchange { get; }

        public string RoutingKey { get; }

        public bool Mandatory { get; } = false;

        public IBasicProperties BasicProperties { get; } = null;
    }
}
