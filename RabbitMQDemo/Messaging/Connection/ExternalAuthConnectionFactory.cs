using System;
using System.Collections.Generic;
using RabbitMQ.Client;

namespace Messaging.Connection
{
    public class ExternalAuthConnectionFactory : SecureConnectionFactory
    {
        public ExternalAuthConnectionFactory(
            string hostname,
            ExternalMechanismFactory externalMechanismFactory,
            SecureConnectionSettings settings)
            : base(settings)
        {
            HostName = string.IsNullOrWhiteSpace(hostname)
                ? throw new ArgumentException(nameof(hostname))
                : hostname;

            AuthMechanisms = externalMechanismFactory == null
                ? throw new ArgumentNullException(nameof(externalMechanismFactory))
                : new List<AuthMechanismFactory> { externalMechanismFactory };
        }
    }
}
