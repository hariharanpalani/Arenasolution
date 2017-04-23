using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingDemo.Common
{
    [Serializable]
    public class Payment
    {
        public double AmountToPay { get; set; }

        public string CardNumber { get; set; }

        public string Name { get; set; }        
    }
}
