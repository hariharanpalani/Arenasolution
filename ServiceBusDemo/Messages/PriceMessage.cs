using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusDemo.Messages
{
    public class PriceMessage : Message
    {
        public double OldPrice { get; set; }

        public double NewPrice { get; set; }

        public int ProductID { get; set; }
    }
}
