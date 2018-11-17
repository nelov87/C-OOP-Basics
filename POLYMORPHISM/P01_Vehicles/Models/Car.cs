using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models
{
    public class Car : Vehicles
    {
        private const double aireCondition = 0.9;

        public Car(double fuelQuantity, double fuelConsuption, double tankCapacyty) : base(fuelQuantity, fuelConsuption, tankCapacyty)
        {
            this.FuelConsumption += aireCondition;
        }
    }
}
