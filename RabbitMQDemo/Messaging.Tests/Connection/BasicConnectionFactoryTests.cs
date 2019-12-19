using System;
using Messaging.Connection;
using Xunit;

namespace Messaging.Tests.Connection
{
    public class BasicConnectionFactoryTests
    {
        [Fact]
        public void BasicConnectionFactory_WhenConstructed_ThenDetailsSet()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "testUser";
            string password = "password123";
            SecureConnectionSettings settings = GetSecureConnectionSettings();

            // Act
            BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                hostname,
                username,
                password,
                settings);

            // Assert
            Assert.Equal(hostname, basicConnectionFactory.HostName);
            Assert.Equal(username, basicConnectionFactory.UserName);
            Assert.Equal(password, basicConnectionFactory.Password);
            Assert.True(basicConnectionFactory.Ssl.Enabled);
            Assert.Equal(settings.ServerName, basicConnectionFactory.Ssl.ServerName);
            Assert.Equal(settings.CertPath, basicConnectionFactory.Ssl.CertPath);
            Assert.Equal(settings.CertPassphrase, basicConnectionFactory.Ssl.CertPassphrase);
            Assert.Equal(settings.Protocol, basicConnectionFactory.Ssl.Version);
        }

        [Theory]
        [MemberData(nameof(Utilities.MemberData.NullOrWhiteSpace), MemberType = typeof(Utilities.MemberData))]
        public void BasicConnectionFactory_WhenHostNameIsNotSupplied_ThenArgumentException(string hostname)
        {
            // Arrange
            string username = "testUser";
            string password = "password123";
            SecureConnectionSettings settings = GetSecureConnectionSettings();

            // Act
            void instantiation()
            {
                BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                    hostname,
                    username,
                    password,
                    settings);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Theory]
        [MemberData(nameof(Utilities.MemberData.NullOrWhiteSpace), MemberType = typeof(Utilities.MemberData))]
        public void BasicConnectionFactory_WhenUsernameIsNotSupplied_ThenArgumentException(string username)
        {
            // Arrange
            string hostname = "127.0.0.1";
            string password = "password123";
            SecureConnectionSettings settings = GetSecureConnectionSettings();

            // Act
            void instantiation()
            {
                BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                    hostname,
                    username,
                    password,
                    settings);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Theory]
        [MemberData(nameof(Utilities.MemberData.NullOrWhiteSpace), MemberType = typeof(Utilities.MemberData))]
        public void BasicConnectionFactory_WhenPasswordIsNotSupplied_ThenArgumentException(string password)
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "testUser";
            SecureConnectionSettings settings = GetSecureConnectionSettings();

            // Act
            void instantiation()
            {
                BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                    hostname,
                    username,
                    password,
                    settings);
            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Fact]
        public void BasicConnectionFactory_WhenSettingsNotSupplied_ThenArgumentNullException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "testUser";
            string password = "password";
            SecureConnectionSettings settings = null;

            // Act
            void instantiation()
            {
                BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                    hostname,
                    username,
                    password,
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
