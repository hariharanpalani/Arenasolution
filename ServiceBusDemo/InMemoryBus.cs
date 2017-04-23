using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusDemo
{
    public class InMemoryBus : IBus
    {
        private readonly IDictionary<string, IMessageHandler> _handlers;

        public InMemoryBus()
        {
            _handlers = new Dictionary<string, IMessageHandler>();
        }

        public void Publish<T>(T message)
        {
            var eventName = typeof(T).Name;

            if (!_handlers.ContainsKey(eventName))
                throw new KeyNotFoundException("No handlers not found for this event");

            var handler = _handlers[eventName];
            handler.GetType().GetMethod("Handle").Invoke(handler, new object[] { message });

        }

        public void Subscribe<T>(IMessageHandler<T> handler) where T : Message
        {
            var eventName = typeof(T).Name;
            _handlers.Add(eventName, handler);
        }
    }
}
