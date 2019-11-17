using System;

namespace Messaging.Contracts
{
    public interface IMessage<T>
    {
        T Data { get; }

        DateTime CreatedAt { get; }
    }
}
