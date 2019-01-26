using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck()
        };

        public AutomatedWarehouse(string name)
            : base(name, capacity: 1, garageSlots: 2, vehicles: DefaultVehicles)
        {
        }

    }
}
