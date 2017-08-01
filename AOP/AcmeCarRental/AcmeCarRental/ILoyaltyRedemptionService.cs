using AcmeCarRental.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCarRental
{
    public interface ILoyaltyRedemptionService
    {
        void Redeem(Invoice invoice, int numberOfDays);
    }
}
