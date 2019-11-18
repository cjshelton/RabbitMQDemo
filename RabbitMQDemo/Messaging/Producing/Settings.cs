using System;
namespace Messaging.Producing
{
    public class Settings
    {
        public Settings(string exchange, string routingKey)
        {
            Exchange = exchange ?? throw new ArgumentNullException(nameof(exchange));
            RoutingKey = routingKey ?? throw new ArgumentNullException(nameof(routingKey));
        }

        public string Exchange { get; }

        public string RoutingKey { get; }
    }
}
