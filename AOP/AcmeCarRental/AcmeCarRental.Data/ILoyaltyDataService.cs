using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCarRental.Data
{
    public interface ILoyaltyDataService
    {
        void AddPoints(Guid id, int points);

        void SubtractPoints(Guid id, int points);
    }
}
