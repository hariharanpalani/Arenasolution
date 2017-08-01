using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCarRental.Data;

namespace AcmeCarRental
{
    public interface ILoyaltyAccrualService
    {
        void Accrue(RentalAgreement agreement);
    }
}
