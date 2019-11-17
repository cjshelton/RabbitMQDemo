using System;
using Moq;
using Utilities.Contracts;
using Xunit;

namespace Messaging.Tests
{
	public class MessageTests
	{
		[Fact]
		public void Message_WhenConstructed_ThenCreatedAtSetToCurrentDateTime()
		{
			Mock<IDateTimeGenerator> mockDateTimeGenerator = new Mock<IDateTimeGenerator>();
			DateTime now = DateTime.Now;
			mockDateTimeGenerator.Setup(dateTimeGenerator => dateTimeGenerator.Now()).Returns(now);
			string data = "test string";

			Message<string> message = new Message<string>(mockDateTimeGenerator.Object, data);

			Assert.Equal(message.CreatedAt, now);
		}

		[Fact]
		public void Message_WhenConstructed_ThenDataSet()
		{
			Mock<IDateTimeGenerator> mockDateTimeGenerator = new Mock<IDateTimeGenerator>();
			string data = "test string";

			Message<string> message = new Message<string>(mockDateTimeGenerator.Object, data);

			Assert.Equal(message.Data, data);
		}
	}
}
