using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusDemo
{
    public interface IBus
    {
        // void Unsubscribe<T>(IMessageHandler<T> handler) where T : Message;
        void Subscribe<T>(IMessageHandler<T> handler) where T : Message;
        void Publish<T>(T message);
    }

    public class Message
    {
        public Guid Id { get; private set; }

        public Message()
        {
            Id = Guid.NewGuid();
        }
    }

    public interface IMessageHandler<T> : IMessageHandler where T : Message
    {
        void Handle(T message);
    }

    public interface IMessageHandler
    {

    }
}
