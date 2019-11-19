using System;
using Messaging.Connection;
using Xunit;

namespace Messaging.Tests.Connection
{
    public class BasicConnectionFactoryTests
    {
        [Fact]
        public void BasicConnectionFactory_WhenConstructed_ThenConnectionDetailsSet()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "testUser";
            string password = "password123";

            // Act
            BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                hostname,
                username,
                password);

            // Assert
            Assert.Equal(hostname, basicConnectionFactory.HostName);
            Assert.Equal(username, basicConnectionFactory.UserName);
            Assert.Equal(password, basicConnectionFactory.Password);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void BasicConnectionFactory_WhenHostNameIsNotSupplied_ThenArgumentException(string hostname)
        {
            // Arrange
            string username = "testUser";
            string password = "password123";

            // Act
            void instantiation()
            {
                BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                    hostname,
                    username,
                    password);

            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void BasicConnectionFactory_WhenUsernameIsNotSupplied_ThenArgumentException(string username)
        {
            // Arrange
            string hostname = "127.0.0.1";
            string password = "password123";

            // Act
            void instantiation()
            {
                BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                    hostname,
                    username,
                    password);

            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void BasicConnectionFactory_WhenPasswordIsNotSupplied_ThenArgumentException(string password)
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "testUser";

            // Act
            void instantiation()
            {
                BasicConnectionFactory basicConnectionFactory = new BasicConnectionFactory(
                    hostname,
                    username,
                    password);

            }

            // Assert
            Assert.Throws<ArgumentException>(instantiation);
        }
    }
}
