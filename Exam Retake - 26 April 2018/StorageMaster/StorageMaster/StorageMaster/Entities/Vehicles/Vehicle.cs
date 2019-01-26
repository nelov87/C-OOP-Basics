using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private int capacity;
        private IList<Product> trunk;
        private bool isFull;
        private bool isEmpty;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public IReadOnlyCollection<Product> Trunk
        {
            get
            {
                return new List<Product>(this.trunk);
            }
        }

        public bool IsFull
        {
            get
            {
                if (this.Trunk.Sum(p => p.Weight) >= this.Capacity)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (this.Trunk.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        public void LoadProduct(Product product)
        {
            if (this.isFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
            
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            IProduct product = this.trunk[trunk.Count - 1];
            this.trunk.RemoveAt(trunk.Count - 1);
            return (Product)product;
        }
    }
}
