using Messaging.Contracts;
using Messaging.Producing;
using Messaging.Tests.Utilities;
using Moq;
using RabbitMQ.Client;
using Utilities.Contracts;
using Xunit;

namespace Messaging.Tests.Producing
{
    public class MessageProducerTests
    {
        [Fact]
        public void MessageProducer_WhenConstructed_ThenConnectionCreated()
        {
            // Arrange
            Dependencies dependencies = GetDependencies();

            dependencies.MockConnection
                .Setup(mockConnection => mockConnection.CreateModel())
                .Returns(dependencies.MockChannel.Object);
            dependencies.MockConnectionFactory
                .Setup(mockConnectionFactory => mockConnectionFactory.CreateConnection())
                .Returns(dependencies.MockConnection.Object);

            // Act
            MessageProducer messageProducer = new MessageProducer(dependencies.MockConnectionFactory.Object, dependencies.MockTypeConverter.Object);

            // Assert
            dependencies.MockConnectionFactory.Verify(mockConnectionFactory => mockConnectionFactory.CreateConnection(), Times.Once);
            dependencies.MockConnection.Verify(mockConnection => mockConnection.CreateModel(), Times.Once);
        }

        [Fact]
        public void Produce_WhenMessageSupplied_ThenMessagePublished()
        {
            // Arrange
            Dependencies dependencies = GetDependencies();

            TestType data = new TestType();
            byte[] byteData = new byte[0];

            Settings settings = new Settings(exchange: "exchange", routingKey: "routingkey");
            IMessage<TestType> message = new TestMessage<TestType>
            {
                Data = data
            };

            dependencies.MockConnection
                .Setup(mockConnection => mockConnection.CreateModel())
                .Returns(dependencies.MockChannel.Object);
            dependencies.MockConnectionFactory
                .Setup(mockConnectionFactory => mockConnectionFactory.CreateConnection())
                .Returns(dependencies.MockConnection.Object);

            dependencies.MockTypeConverter
                .Setup(mockTypeConverter => mockTypeConverter.ToByteArray(data))
                .Returns(byteData);

            MessageProducer messageProducer = new MessageProducer(dependencies.MockConnectionFactory.Object, dependencies.MockTypeConverter.Object);

            // Act
            messageProducer.Produce(settings, message);

            // Assert
            dependencies.MockChannel.Verify(mockChannel => mockChannel.BasicPublish(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<IBasicProperties>(),
                byteData), Times.Once);
        }

        [Fact]
        public void Produce_WhenSettingsSupplied_ThenSettingsUsedForPublish()
        {
            // Arrange
            Dependencies dependencies = GetDependencies();

            TestType data = new TestType();
            byte[] byteData = new byte[0];

            Settings settings = new Settings(exchange: "exchange", routingKey: "routingkey");
            IMessage<TestType> message = new TestMessage<TestType>
            {
                Data = data
            };

            dependencies.MockConnection
                .Setup(mockConnection => mockConnection.CreateModel())
                .Returns(dependencies.MockChannel.Object);
            dependencies.MockConnectionFactory
                .Setup(mockConnectionFactory => mockConnectionFactory.CreateConnection())
                .Returns(dependencies.MockConnection.Object);

            dependencies.MockTypeConverter
                .Setup(mockTypeConverter => mockTypeConverter.ToByteArray(data))
                .Returns(byteData);

            MessageProducer messageProducer = new MessageProducer(
                dependencies.MockConnectionFactory.Object,
                dependencies.MockTypeConverter.Object);

            // Act
            messageProducer.Produce(settings, message);

            // Assert
            dependencies.MockChannel.Verify(mockChannel => mockChannel.BasicPublish(
                settings.Exchange,
                settings.RoutingKey,
                It.IsAny<bool>(),
                It.IsAny<IBasicProperties>(),
                It.IsAny<byte[]>()), Times.Once);
        }

        private Dependencies GetDependencies()
        {
            return new Dependencies
            {
                MockConnectionFactory = new Mock<IConnectionFactory>(),
                MockConnection = new Mock<IConnection>(),
                MockChannel = new Mock<IModel>(),
                MockTypeConverter = new Mock<ITypeConverter>()
            };
        }

        private class Dependencies
        {
            public Mock<IConnectionFactory> MockConnectionFactory { get; set; }
            public Mock<IConnection> MockConnection { get; set; }
            public Mock<IModel> MockChannel { get; set; }
            public Mock<ITypeConverter> MockTypeConverter { get; set; }
        }
    }
}
