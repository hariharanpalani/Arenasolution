using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCarRental.Data;

namespace AcmeCarRental
{
    public class LoyaltyAccuralService : ILoyaltyAccrualService
    {
        private readonly ILoyaltyDataService _dataService;

        public LoyaltyAccuralService(ILoyaltyDataService service)
        {
            _dataService = service;
        }

        public void Accrue(RentalAgreement agreement)
        {
            var pointsPerDay = 1;
            var rentalTimeSpan = agreement.EndDate.Subtract(agreement.StartDate);
            var numberOfDays = (int)Math.Floor(rentalTimeSpan.TotalDays);

            if (agreement.Vehicle.Size > Size.FullSize)
                pointsPerDay = 2;

            var totalPoints = numberOfDays * pointsPerDay;

            _dataService.AddPoints(agreement.Customer.Id, totalPoints);
        }
    }
}
