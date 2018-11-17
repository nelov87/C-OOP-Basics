using StorageMaster.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Products
{
    public class Gpu : Product
    {
        private const double weightOfGPU = 0.7;

        public Gpu(double price) : base(price, weightOfGPU)
        {
            
        }
    }
}
