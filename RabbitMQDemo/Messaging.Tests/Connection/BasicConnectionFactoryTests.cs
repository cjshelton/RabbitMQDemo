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

        [Fact]
        public void BasicConnectionFactory_WhenHostNameIsNull_ThenArgumentException()
        {
            // Arrange
            string hostname = null;
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

        [Fact]
        public void BasicConnectionFactory_WhenHostNameIsEmpty_ThenArgumentException()
        {
            // Arrange
            string hostname = string.Empty;
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

        [Fact]
        public void BasicConnectionFactory_WhenHostNameIsWhiteSpace_ThenArgumentException()
        {
            // Arrange
            string hostname = "  ";
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

        [Fact]
        public void BasicConnectionFactory_WhenUsernameIsNull_ThenArgumentException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = null;
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

        [Fact]
        public void BasicConnectionFactory_WhenUsernameIsEmpty_ThenArgumentException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = string.Empty;
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

        [Fact]
        public void BasicConnectionFactory_WhenUsernameIsWhiteSpace_ThenArgumentException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "  ";
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

        [Fact]
        public void BasicConnectionFactory_WhenPasswordIsNull_ThenArgumentException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "testUser";
            string password = null;

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

        [Fact]
        public void BasicConnectionFactory_WhenPasswordIsEmpty_ThenArgumentException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "testUser";
            string password = string.Empty;

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

        [Fact]
        public void BasicConnectionFactory_WhenPasswordIsWhiteSpace_ThenArgumentException()
        {
            // Arrange
            string hostname = "127.0.0.1";
            string username = "testUser";
            string password = "  ";

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
