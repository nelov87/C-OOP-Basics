using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models
{
    public class Truck : Vehicles
    {
        private const double aireCondition = 1.6;

        public Truck(double fuelQuantity, double fuelConsuption, double tankCapacyty) : base(fuelQuantity, fuelConsuption, tankCapacyty)
        {
            FuelConsumption += aireCondition;
            
        }

        public override void Refuel(double fuelAmaunt)
        {
            if (fuelAmaunt <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuelAmaunt > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmaunt} fuel in the tank");
            }

            this.FuelQuantity += fuelAmaunt * 0.95;

        }
    }
}
