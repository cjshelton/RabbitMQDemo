using System;
using RabbitMQ.Client;

namespace Messaging.Connection
{
    public abstract class SecureConnectionFactory : ConnectionFactory
    {
        protected SecureConnectionFactory(SecureConnectionSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            Ssl.Enabled = true;
            Ssl.ServerName = settings.ServerName;
            Ssl.CertPath = settings.CertPath;
            Ssl.CertPassphrase = settings.CertPassphrase;
            Ssl.Version = settings.Protocol;
            Port = settings.Port;
        }
    }
}
