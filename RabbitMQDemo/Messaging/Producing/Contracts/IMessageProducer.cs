using System;
using Messaging.Contracts;

namespace Messaging.Producing.Contracts
{
    public interface IMessageProducer : IDisposable
    {
        void Produce<T>(Settings settings, IMessage<T> message);
    }
}
