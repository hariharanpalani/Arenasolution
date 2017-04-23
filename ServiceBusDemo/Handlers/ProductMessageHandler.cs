using ServiceBusDemo.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusDemo.Handlers
{
    public class ProductMessageHandler : IMessageHandler<ProductMessage>
    {
        public void Handle(ProductMessage message)
        {
            Console.WriteLine($"Message received for product information: {message.Name}");
        }
    }
}
