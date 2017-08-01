using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCarRental.Data
{
    public class Customer
    {
        public Guid Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string DriverLicense { get; set; }

        public string Name { get; set; }
    }
}
