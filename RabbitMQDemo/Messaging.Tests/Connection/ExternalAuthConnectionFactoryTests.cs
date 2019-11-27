using System;
using System.Linq;
using Messaging.Connection;
using RabbitMQ.Client;
using Xunit;

namespace Messaging.Tests.Connection
{
    public class ExternalAuthConnectionFactoryTests
    {
        [Fact]
        public void ExternalAuthConnectionFactory_WhenConstructed_ThenDetailsSet()
        {
            // Arrange
            string hostname = "127.0.0.1";
            SecureConnectionSettings settings = GetSecureConnectionSettings();
            ExternalMechanismFactory externalMechanismFactory = new ExternalMechanismFactory();

            // Act
            ExternalAuthConnectionFactory externalAuthConnectionFactory = new ExternalAuthConnectionFactory(
                hostname,
                externalMechanismFactory,
                settings);

            // Assert
            Assert.Equal(hostname, externalAuthConnectionFactory.HostName);
            Assert.True(externalAuthConnectionFactory.Ssl.Enabled);
            Assert.Equal(settings.ServerName, externalAuthConnectionFactory.Ssl.ServerName);
            Assert.Equal(settings.CertPath, externalAuthConnectionFactory.Ssl.CertPath);
            Assert.Equal(settings.CertPassphrase, externalAuthConnectionFactory.Ssl.CertPassphrase);
            Assert.Equal(settings.Protocol, externalAuthConnectionFactory.Ssl.Version);
        }

        [Fact]
        public void ExternalAuthConnectionFactory_WhenConstructed_ThenExternalAuthMechanismSet()
        {
            // Arrange
            string hostname = "127.0.0.1";
            SecureConnectionSettings settings = GetSecureConnectionSettings();
            ExternalMechanismFactory externalMechanismFactory = new ExternalMechanismFactory();

            // Act
            ExternalAuthConnectionFactory externalAuthConnectionFactory = new ExternalAuthConnectionFactory(
                hostname,
                externalMechanismFactory,
                settings);

            // Assert
            Assert.NotNull(externalAuthConnectionFactory.AuthMechanisms);
            Assert.Single(externalAuthConnectionFactory.AuthMechanisms);
            Assert.Same(externalMechanismFactory, externalAuthConnectionFactory.AuthMechanisms.First());
        }

        [Theory]
        [MemberData(nameof(Utilities.MemberData.NullOrWhiteSpace), MemberType = typeof(Utilities.MemberData))]
        public void ExternalAuthConnectionFactory_WhenHostNameIsNotSupplied_ThenArgumentException(string hostname)
        {
            // Arrange
            SecureConnectionSettings settings = GetSecureConnectionSettings();
            ExternalMechanismFactory externalMechanismFactory = new ExternalMechanismFactory();

            // Act
            void instantiation()
            {
                ExternalAuthConnectionFactory externalAuthConnectionFactory = new ExternalAuthConnectionFactory(
                    hostname,
                    externalMechanismFactory,
                    settings);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Fact]
        public void ExternalAuthConnectionFactory_WhenSettingsNotSupplied_ThenArgumentNullException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            SecureConnectionSettings settings = null;
            ExternalMechanismFactory externalMechanismFactory = new ExternalMechanismFactory();

            // Act
            void instantiation()
            {
                ExternalAuthConnectionFactory externalAuthConnectionFactory = new ExternalAuthConnectionFactory(
                    hostname,
                    externalMechanismFactory,
                    settings);
            }

            // Assert
            Assert.Throws<ArgumentNullException>(instantiation);
        }

        [Fact]
        public void ExternalAuthConnectionFactory_WhenExternalAuthMechanismNotSupplied_ThenArgumentNullException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            SecureConnectionSettings settings = GetSecureConnectionSettings();
            ExternalMechanismFactory externalMechanismFactory = null;

            // Act
            void instantiation()
            {
                ExternalAuthConnectionFactory externalAuthConnectionFactory = new ExternalAuthConnectionFactory(
                    hostname,
                    externalMechanismFactory,
                    settings);
            }

            // Assert
            Assert.Throws<ArgumentNullException>(instantiation);
        }

        private static SecureConnectionSettings GetSecureConnectionSettings()
        {
            return new SecureConnectionSettings(
                "localhost",
                "/path/to/cert",
                "password");
        }
    }
}

