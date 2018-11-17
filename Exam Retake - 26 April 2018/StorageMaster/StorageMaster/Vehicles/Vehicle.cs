using StorageMaster.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using StorageMaster.Products;

namespace StorageMaster.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private int capacity;
        private List<Product> products;
        private IReadOnlyCollection<Product> trunk;
        private bool isFull;
        private bool isEmpty;

        

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Trunk
        {
            get
            {
                return this.products.AsReadOnly();
            }
            
        }

        public bool IsEmpty
        {
            get
            {
                return isEmpty;
            }
            set
            {
                if (Trunk.Count() == 0)
                {
                    this.isEmpty = true;
                }
                else
                {
                    this.isEmpty = false;
                }
            }
        }


        public bool IsFull
        {
            get
            {
                if (Trunk.Sum(t => t.Weight) >= Capacity)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
        }

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            else
            {
                this.products.Add(product);
            }
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            
                Product lastProduct = products.Last();
                this.products.RemoveAt(products.Count() - 1);
                return lastProduct;
                
            
        }
    }
}
