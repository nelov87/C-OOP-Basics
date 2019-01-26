﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public class Semi : Vehicle
    {
        private const int initialCapacitySemi = 10;

        public Semi() : base(initialCapacitySemi)
        {
        }
    }
}
