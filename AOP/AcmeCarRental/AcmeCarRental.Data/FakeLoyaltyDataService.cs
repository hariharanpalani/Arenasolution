using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCarRental.Data
{
    public class FakeLoyaltyDataService : ILoyaltyDataService
    {
        public void AddPoints(Guid id, int points)
        {
            Console.WriteLine($"Customer id {id} gains {points} reward points");
        }

        public void SubtractPoints(Guid id, int points)
        {
            Console.WriteLine($"Customer id {id} used {points} reward points");
        }
    }
}
