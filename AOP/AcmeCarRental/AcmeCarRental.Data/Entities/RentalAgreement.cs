using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCarRental.Data
{
    public class RentalAgreement
    {
        public Guid Id { get; set; }

        public Customer Customer { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
