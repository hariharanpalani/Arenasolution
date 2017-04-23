using ServiceBusDemo.Handlers;
using ServiceBusDemo.Messages;
using System;
using System.Linq;
using System.Threading;

namespace ServiceBusDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new RabbitMqBus();
            DoPriceHandler(bus);
            DoProductHandler(bus);
            for(int i = 1;i <= 10; i++)
            {
                Thread.Sleep(500);
                if (i % 2 == 0)
                {
                    bus.Publish(new PriceMessage
                    {
                        ProductID = i,
                        NewPrice = i * 400,
                        OldPrice = new Random().Next(10, 20) * i
                    });
                }
                else
                {
                    bus.Publish(new ProductMessage
                    {
                        Amount = 200,
                        Name = $"Product {i}"
                    });
                }
            }
            Console.ReadKey();
        }

        private static void DoPriceHandler(IBus bus)
        {
            var messageHandler = new PriceMessageHandler();
            bus.Subscribe(messageHandler);
        }

        private static void DoProductHandler(IBus bus)
        {
            var messageHandler = new ProductMessageHandler();
            bus.Subscribe(messageHandler);
        }
    }
}