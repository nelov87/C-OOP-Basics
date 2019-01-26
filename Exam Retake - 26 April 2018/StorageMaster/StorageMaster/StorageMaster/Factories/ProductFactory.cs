using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public IProduct CreateProduct(string type, double price)
        {
            IProduct product;
            switch (type)
            {
                case "Gpu":
                    product = new Gpu(price);
                    return product;
                case "HardDrive":
                    product = new HardDrive(price);
                    return product;
                case "Ram":
                    product = new Ram(price);
                    return product;
                case "SolidStateDrive":
                    product = new SolidStateDrive(price);
                    return product;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }
        }
    }
}
