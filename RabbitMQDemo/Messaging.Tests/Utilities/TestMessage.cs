using System;
using Messaging.Contracts;

namespace Messaging.Tests.Utilities
{
    internal class TestMessage<T> : IMessage<T>
    {
        public T Data { get; set; }

        public DateTime CreatedAt => DateTime.Now;
    }
}
