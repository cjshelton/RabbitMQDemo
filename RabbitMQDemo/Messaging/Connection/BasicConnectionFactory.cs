using System;

namespace Messaging.Connection
{
    public class BasicConnectionFactory : SecureConnectionFactory
    {
        public BasicConnectionFactory(string hostname, string username, string password, SecureConnectionSettings settings)
            : base(settings)
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
