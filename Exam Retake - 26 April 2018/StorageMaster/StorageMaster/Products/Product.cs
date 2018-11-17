using StorageMaster.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Products
{
    public abstract class Product : IProduct
    {
        private double price;
        private double weight;

        public Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public double Price
        {
            get
            {
                return price;
            }
             set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                else
                {
                    price = value;
                }
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Wight cannot be negative!");
                }
                else
                {
                    weight = value;
                }
            }
        }
    }
}
