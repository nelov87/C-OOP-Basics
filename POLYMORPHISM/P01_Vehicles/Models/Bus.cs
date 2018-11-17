using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models
{
    public class Bus : Vehicles
    {
        private const double aireConditionConsimption = 1.4;

        public Bus(double fuelQuantity, double fuelConsuption, double tankCapacyty) : base(fuelQuantity, fuelConsuption, tankCapacyty)
        {

        }

        public override void Drive(double distance)
        {
            double currentFuelConsumption = this.FuelConsumption;

            if (!IsVehicleEmpty)
            {
                currentFuelConsumption += aireConditionConsimption;
            }

            double neededFuel = distance * currentFuelConsumption;

            if (this.FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");

            }

            this.FuelQuantity -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }
}
