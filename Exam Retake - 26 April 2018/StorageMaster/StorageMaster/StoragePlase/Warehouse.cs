using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.StoragePlase
{
    public class Warehouse : Storage
    {
        private const int maxGarageSlots = 10;
        private const int maxCapacity = 10;
        private List<Vehicle> defautVehicles = new List<Vehicle>();
        private static Vehicle[] DefaultVehicals =
        {

            new Semi(),
            new Semi(),
            new Semi()

        };

        public Warehouse(string name) : base(name, maxCapacity, maxGarageSlots, DefaultVehicals)
        {
            
        }

        
    }
}
