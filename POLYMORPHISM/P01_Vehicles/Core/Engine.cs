using P01_Vehicles.Models;
using P01_Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            // Car {fuel quantity} {liters per km}
            // Truck {fuel quantity} {liters per km}
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            double carCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busCapacity = double.Parse(busInfo[3]);

            IVehicles car = new Car(carFuelQuantity, carConsumption, carCapacity);
            IVehicles truck = new Truck(truckFuelQuantity, truckConsumption, truckCapacity);
            IVehicles bus = new Bus(busFuelQuantity, busConsumption, busCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //• "Drive Car {distance}"
                //• "Drive Truck {distance}"
                //• "Refuel Car {liters}"
                //• "Refuel Truck {liters}"

                string[] inputArgs = Console.ReadLine().Split();

                string action = inputArgs[0];
                string vehicleType = inputArgs[1];
                double value = double.Parse(inputArgs[2]);

                try
                {
                    if (action == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Drive(value);
                        }
                        else if(vehicleType == "Truck")
                        {
                            truck.Drive(value);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.IsVehicleEmpty = false;
                            bus.Drive(value);
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.IsVehicleEmpty = true;
                        bus.Drive(value);
                    }
                    else if (action == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message); ;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
