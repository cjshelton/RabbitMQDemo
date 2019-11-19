using Messaging.Producing;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;
using Xunit;

namespace Messaging.Tests.Producing
{
    public class SettingsTests
    {
        [Fact]
        public void Settings_WhenConstructed_ThenSettingsSet()
        {
            // Arrange
            string exchange = "exchange";
            string routingKey = "routing key";
            bool mandatory = true;
            IBasicProperties basicProperties = new BasicProperties();

            // Act
            Settings settings = new Settings(exchange, routingKey, mandatory, basicProperties);

            // Assert
            Assert.Equal(exchange, settings.Exchange);
            Assert.Equal(routingKey, settings.RoutingKey);
            Assert.Equal(mandatory, settings.Mandatory);
            Assert.Same(basicProperties, settings.BasicProperties);
        }

        [Fact]
        public void Settings_WhenMandatoryNotSupplied_ThenMandatorySetToDefault()
        {
            // Arrange
            string exchange = "exchange";
            string routingKey = "routing key";
            IBasicProperties basicProperties = new BasicProperties();

            // Act
            Settings settings = new Settings(exchange, routingKey, basicProperties);

            // Assert
            Assert.Equal(false, settings.Mandatory);
        }

        [Fact]
        public void Settings_WhenBasicPropertiesNotSupplied_ThenBasicPropertiesSetToDefault()
        {
            // Arrange
            string exchange = "exchange";
            string routingKey = "routing key";
            bool mandatory = true;

            // Act
            Settings settings = new Settings(exchange, routingKey, mandatory);

            // Assert
            Assert.Null(settings.BasicProperties);
        }
    }
}
