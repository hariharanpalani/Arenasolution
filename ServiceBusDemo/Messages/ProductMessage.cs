using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusDemo.Messages
{
    public class ProductMessage : Message
    {
        public string Name { get; set; }

        public double Amount { get; set; }
    }
}
