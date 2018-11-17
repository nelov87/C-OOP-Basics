using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models.Interfaces
{
    public interface IVehicles
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }

        bool IsVehicleEmpty { get; set; }
        void Drive(double distance);
        void Refuel(double fuelAmaunt);

    }
}
