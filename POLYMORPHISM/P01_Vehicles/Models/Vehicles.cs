using P01_Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models
{
    public abstract class Vehicles : IVehicles
    {
        private double tankCapacity;
        private double fuelQuantity;
        private double fuelConsumption;
        

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {

                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            set
            {
                fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            set
            {
                tankCapacity = value;
            }
        }

        public bool IsVehicleEmpty { get; set; }

        public Vehicles(double fuelQuantity, double fuelConsuption, double tankCapacyty)
        {
            this.TankCapacity = tankCapacyty;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsuption;
            
        }

        

        public virtual void Drive(double distance)
        {
            double currentFuelConsumption = this.FuelConsumption;

            double neededFuel = distance * this.FuelConsumption;

            if (this.FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
                
            }

            this.FuelQuantity -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double fuelAmaunt)
        {
            if (fuelAmaunt <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuelAmaunt > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmaunt} fuel in the tank");
            }
           
            this.FuelQuantity += fuelAmaunt;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}


//
//