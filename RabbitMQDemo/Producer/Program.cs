using System;
using Messaging;
using Messaging.Connection;
using Messaging.Contracts;
using Messaging.Producing;
using Messaging.Producing.Contracts;
using RabbitMQ.Client;
using Utilities;
using Utilities.Contracts;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependencies.
            IDateTimeGenerator dateTimeGenerator = new DateTimeGenerator();
            ITypeConverter typeConverter = new TypeConverter();
            ExternalMechanismFactory externalMechanismFactory = new ExternalMechanismFactory();

            SecureConnectionSettings connectionSettings = new SecureConnectionSettings(
                "raspberrypi",
                "/path/to/client/certiicate.p12",
                "password");

            ExternalAuthConnectionFactory sslAuthConnectionFactory = new ExternalAuthConnectionFactory(
                "raspberrypi",
                externalMechanismFactory,
                connectionSettings);

            Settings producingSettings = new Settings("Journeys", "journey");

            // Generate journey message.
            Journey journey = new Journey(150, 35.5, 121.3, "Weather was wet and windy.");
            IMessage<Journey> message = new Message<Journey>(dateTimeGenerator, journey);

            // Produce the message.
            using IMessageProducer messageProducer = new MessageProducer(sslAuthConnectionFactory, typeConverter);
            messageProducer.Produce(producingSettings, message);

            Console.WriteLine($"Message sent. ID: {message.Data.Id}");
            Console.ReadLine();
        }
    }
}
