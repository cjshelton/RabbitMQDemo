using System;
using System.Security.Authentication;

namespace Messaging.Connection
{
    public class SecureConnectionSettings
    {
        private const int MIN_PORT = 1;
        private const int MAX_PORT = 65535;

        public SecureConnectionSettings(string serverName, string certPath, string certPassphrase)
        {
            ServerName = string.IsNullOrWhiteSpace(serverName)
                ? throw new ArgumentException(nameof(serverName))
                : serverName;

            CertPath = string.IsNullOrWhiteSpace(certPath)
                ? throw new ArgumentException(nameof(certPath))
                : certPath;

            CertPassphrase = string.IsNullOrWhiteSpace(certPassphrase)
                ? throw new ArgumentException(nameof(certPassphrase))
                : certPassphrase;
        }

        public SecureConnectionSettings(string serverName, string certPath, string certPassphrase, int port)
            : this(serverName, certPath, certPassphrase)
        {
            Port = (port < MIN_PORT || port > MAX_PORT)
                ? throw new ArgumentException($"Port must be between {MIN_PORT}-{MAX_PORT} (inclusive).", nameof(port))
                : port;
        }

        public SecureConnectionSettings(string serverName, string certPath, string certPassphrase, SslProtocols protocol)
            : this(serverName, certPath, certPassphrase)
        {
            Protocol = Enum.IsDefined(typeof(SslProtocols), protocol)
                ? protocol
                : throw new ArgumentException($"Protocol is not valid: {protocol}.", nameof(protocol));
        }

        public SecureConnectionSettings(string serverName, string certPath, string certPassphrase, int port, SslProtocols protocol)
            : this(serverName, certPath, certPassphrase, port)
        {
            Protocol = Enum.IsDefined(typeof(SslProtocols), protocol)
                ? protocol
                : throw new ArgumentException($"Protocol is not valid: {protocol}.", nameof(protocol));
        }

        public string ServerName { get; }

        public string CertPath { get; }

        public string CertPassphrase { get; }

        public int Port { get; } = 5671;

        public SslProtocols Protocol { get; } = SslProtocols.Tls12;
    }
}
