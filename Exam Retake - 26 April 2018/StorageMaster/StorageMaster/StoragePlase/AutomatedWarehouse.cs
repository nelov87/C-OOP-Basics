using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.StoragePlase
{
    public class AutomatedWarehouse : Storage
    {
        private const int maxGarageSlots = 2;
        private const int maxCapacity = 1;
        private List<Vehicle> defautVehicles = new List<Vehicle>();
        private static Vehicle[] DefaultVehicals = 
        {

            new Truck()

        };

        public AutomatedWarehouse(string name) : base(name, maxCapacity, maxGarageSlots, DefaultVehicals)
        {
        }

        
        //string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles

    }
}
