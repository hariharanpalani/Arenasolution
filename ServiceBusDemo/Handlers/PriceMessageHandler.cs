using ServiceBusDemo.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusDemo.Handlers
{
    public class PriceMessageHandler : IMessageHandler<PriceMessage>
    {
        public void Handle(PriceMessage message)
        {
            Console.WriteLine($"Price change for the product id {message.ProductID} with price {message.OldPrice} to {message.NewPrice}");
        }
    }
}
