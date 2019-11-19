using System;
using RabbitMQ.Client;

namespace Messaging.Connection
{
    public class BasicConnectionFactory : ConnectionFactory
    {
        public BasicConnectionFactory(string hostname, string username, string password)
        {
            HostName = string.IsNullOrWhiteSpace(hostname)
                ? throw new ArgumentException(nameof(hostname))
                : hostname;

            UserName = string.IsNullOrWhiteSpace(username)
                ? throw new ArgumentException(nameof(username))
                : username;

            Password = string.IsNullOrWhiteSpace(password)
                ? throw new ArgumentException(nameof(password))
                : password;
        }
    }
}
