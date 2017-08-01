using AcmeCarRental.Data;
using AcmeCarRental.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCarRental.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            StimulateAddingPoints();
            StimulateRemovePoints();
            Console.ReadLine();
        }

        static void StimulateAddingPoints()
        {
            var dataService = new FakeLoyaltyDataService();
            var service = new LoyaltyAccuralService(dataService);
            var rentalAgreement = new RentalAgreement
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now,
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now.AddYears(-25),
                    DriverLicense = "DL0012345",
                    Name = "John Papa"
                },
                Vehicle = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Make = "Honda",
                    Model = "Sedan",
                    Size = Size.Compact
                }
            };
            service.Accrue(rentalAgreement);
        }

        static void StimulateRemovePoints()
        {
            var dataService = new FakeLoyaltyDataService();
            var service = new LoyaltyRedemptionService(dataService);
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CostPerDay = 29.95m,
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now.AddYears(-25),
                    DriverLicense = "DL0012345",
                    Name = "John Papa"
                },
                Vehicle = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Make = "Honda",
                    Model = "SUV",
                    Size = Size.Luxury
                }
            };
            service.Redeem(invoice, 3);
        }
    }
}
