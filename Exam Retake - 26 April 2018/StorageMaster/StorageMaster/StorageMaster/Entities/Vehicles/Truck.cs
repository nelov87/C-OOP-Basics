using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        private const int initialCapacityTruck = 5;

        public Truck() : base(initialCapacityTruck)
        {
        }
    }
}
