using System;
using System.Collections.Generic;
using System.Security.Authentication;
using Messaging.Connection;
using Xunit;

namespace Messaging.Tests.Connection
{
    public class SecureConnectionSettingsTests
    {
        [Fact]
        public void SecureConnectionSettings_WhenConstructed_ThenConnectionDetailsSet()
        {
            // Arrange
            const string serverName = "localhost";
            const string certPath = "/path/to/cert";
            const string certPassphrase = "password";
            const int port = 1;
            const SslProtocols protocol = SslProtocols.Tls12;

            // Act
            SecureConnectionSettings secureConnectionSettings = new SecureConnectionSettings(
                serverName,
                certPath,
                certPassphrase,
                port,
                protocol);

            // Assert
            Assert.Equal(serverName, secureConnectionSettings.ServerName);
            Assert.Equal(certPath, secureConnectionSettings.CertPath);
            Assert.Equal(certPassphrase, secureConnectionSettings.CertPassphrase);
            Assert.Equal(port, secureConnectionSettings.Port);
            Assert.Equal(protocol, secureConnectionSettings.Protocol);
        }

        [Theory]
        [MemberData(nameof(Utilities.MemberData.NullOrWhiteSpace), MemberType = typeof(Utilities.MemberData))]
        public void SecureConnectionSettings_WhenServerNameNotSupplied_ThenArgumentException(string serverName)
        {
            // Arrange  
            const string certPath = "/path/to/cert";
            const string certPassphrase = "password";
            const int port = 1;
            const SslProtocols protocol = SslProtocols.Tls12;

            // Act
            void instantiation()
            {
                SecureConnectionSettings secureConnectionSettings = new SecureConnectionSettings(
                    serverName,
                    certPath,
                    certPassphrase,
                    port,
                    protocol);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Theory]
        [MemberData(nameof(Utilities.MemberData.NullOrWhiteSpace), MemberType = typeof(Utilities.MemberData))]
        public void SecureConnectionSettings_WhenCertPathNotSupplied_ThenArgumentException(string certPath)
        {
            // Arrange
            const string serverName = "localhost";
            const string certPassphrase = "password";
            const int port = 1;
            const SslProtocols protocol = SslProtocols.Tls12;

            // Act
            void instantiation()
            {
                SecureConnectionSettings secureConnectionSettings = new SecureConnectionSettings(
                    serverName,
                    certPath,
                    certPassphrase,
                    port,
                    protocol);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Theory]
        [MemberData(nameof(Utilities.MemberData.NullOrWhiteSpace), MemberType = typeof(Utilities.MemberData))]
        public void SecureConnectionSettings_WhenCertPassphraseNotSupplied_ThenArgumentException(string certPassphrase)
        {
            // Arrange
            const string serverName = "localhost";
            const string certPath = "/path/to/cert";
            const int port = 1;
            const SslProtocols protocol = SslProtocols.Tls12;

            // Act
            void instantiation()
            {
                SecureConnectionSettings secureConnectionSettings = new SecureConnectionSettings(
                    serverName,
                    certPath,
                    certPassphrase,
                    port,
                    protocol);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Fact]
        public void SecureConnectionSettings_WhenPortNotSupplied_ThenDefaultPortSet()
        {
            // Arrange
            const int DEFAULT_PORT = 5671;
            const string serverName = "localhost";
            const string certPath = "/path/to/cert";
            const string certPassphrase = "password";
            const SslProtocols protocol = SslProtocols.Tls12;

            // Act
            SecureConnectionSettings secureConnectionSettings = new SecureConnectionSettings(
                serverName,
                certPath,
                certPassphrase,
                protocol);

            // Assert
            Assert.Equal(DEFAULT_PORT, secureConnectionSettings.Port);
        }

        [Theory]
        [MemberData(nameof(OutOfBoundPorts))]
        public void SecureConnectionSettings_WhenPortOutOfBounds_ThenArgumentException(int port)
        {
            // Arrange
            const string serverName = "localhost";
            const string certPath = "/path/to/cert";
            const string certPassphrase = "password";

            // Act
            // Act
            void instantiation()
            {
                SecureConnectionSettings secureConnectionSettings = new SecureConnectionSettings(
                    serverName,
                    certPath,
                    certPassphrase,
                    port);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Fact]
        public void SecureConnectionSettings_WhenProtocolNotSupplied_ThenDefaultProtocolSet()
        {
            // Arrange
            const SslProtocols DEFAULT_PROTOCOL = SslProtocols.Tls12;
            const string serverName = "localhost";
            const string certPath = "/path/to/cert";
            const string certPassphrase = "password";

            // Act
            SecureConnectionSettings secureConnectionSettings = new SecureConnectionSettings(
                serverName,
                certPath,
                certPassphrase);

            // Assert
            Assert.Equal(DEFAULT_PROTOCOL, secureConnectionSettings.Protocol);
        }

        [Fact]
        public void SecureConnectionSettings_WhenProtocolInvalid_ThenArgumentException()
        {
            // Arrange
            const SslProtocols INVALID_PROTOCOL = (SslProtocols)100;
            const string serverName = "localhost";
            const string certPath = "/path/to/cert";
            const string certPassphrase = "password";

            // Act
            // Act
            void instantiation()
            {
                SecureConnectionSettings secureConnectionSettings = new SecureConnectionSettings(
                    serverName,
                    certPath,
                    certPassphrase,
                    INVALID_PROTOCOL);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        public static IEnumerable<object[]> OutOfBoundPorts =>
            new List<object[]>
            {
                new object[] { -1 },
                new object[] { 0 },
                new object[] { 65536 },
                new object[] { 65537 },
            };
    }
}
