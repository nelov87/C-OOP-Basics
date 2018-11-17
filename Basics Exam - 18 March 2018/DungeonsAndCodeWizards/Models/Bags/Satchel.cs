﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Satchel : Bag
    {
        private const int satchelCapacity = 20;

        public Satchel() : base(satchelCapacity)
        {
        }
    }
}
