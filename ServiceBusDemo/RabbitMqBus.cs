using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ServiceBusDemo
{
    public class RabbitMqBus : IBus, IDisposable
    {
        private readonly string Exchange_Name = "Demo_Exchanges";
        private readonly IDictionary<string, IMessageHandler> _handlers;
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;

        public RabbitMqBus()
        {
            _handlers = new Dictionary<string, IMessageHandler>();
        }

        public void Publish<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var serializedString = JsonConvert.SerializeObject(message);

            using(var connection = factory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    model.ExchangeDeclare(Exchange_Name, "direct");
                    model.BasicPublish(Exchange_Name, typeof(T).Name, null, Encoding.UTF8.GetBytes(serializedString));
                }
            }
        }

        public void Subscribe<T>(IMessageHandler<T> handler) where T : Message
        {
            var eventName = typeof(T).Name;

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, handler);
            }

            if (_connection == null)
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest"
                };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(Exchange_Name, "direct");
                _queueName = _channel.QueueDeclare().QueueName;
            }

            _channel.QueueBind(_queueName, Exchange_Name, eventName, null);
            var eventConsumer = new EventingBasicConsumer(_channel);
            eventConsumer.Received += (sender, e) =>
            {
                var key = e.RoutingKey;
                var jsonString = Encoding.UTF8.GetString(e.Body);
                var currentHandler = _handlers[key];
                var type = currentHandler.GetType().GetInterfaces().First().GetGenericArguments().First();
                var concreteType = typeof(IMessageHandler<>).MakeGenericType(type);
                var msg = JsonConvert.DeserializeObject(jsonString, type);
                concreteType.GetMethod("Handle").Invoke(currentHandler, new object[] { msg });
            };

            _channel.BasicConsume(_queueName, true, eventConsumer);
        }

        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}
