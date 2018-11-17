using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.StoragePlase
{
    public class DistributionCenter : Storage
    {
        private const int maxGarageSlots = 5;
        private const int maxCapacity = 2;
        private List<Vehicle> defautVehicles = new List<Vehicle>();
        private static Vehicle[] DefaultVehicals =
        {

            new Van(),
            new Van(),
            new Van()

        };

        public DistributionCenter(string name) : base(name, maxCapacity, maxGarageSlots, DefaultVehicals)
        {
            
        }

        
    }
}
