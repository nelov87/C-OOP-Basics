using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Products
{
    public class HardDrive : Product
    {
        private const double weightOhHardDrive = 1.0;

        public HardDrive(double price) : base(price, weightOhHardDrive)
        {
            
        }
    }
}
