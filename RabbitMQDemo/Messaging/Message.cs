using System;
using Messaging.Contracts;
using Utilities.Contracts;

namespace Messaging
{
    public class Message<T> : IMessage<T>
    {
        public Message(IDateTimeGenerator dateTime, T data)
        {
            Data = data;
            CreatedAt = dateTime.Now();
        }

        public T Data { get; }

        public DateTime CreatedAt { get; }
    }
}
