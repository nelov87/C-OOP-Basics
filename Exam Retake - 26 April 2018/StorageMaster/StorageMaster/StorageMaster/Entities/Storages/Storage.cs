using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage : IStorage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private bool isFull;
        private Vehicle[] garage;
        private IList<Product> products;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[garageSlots];
            InitializeGarage(vehicles);
            this.products = new List<Product>();
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            int counter = 0;

            foreach (var vehicle in vehicles)
            {
                garage[counter] = vehicle;
                counter++;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
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

        public int GarageSlots
        {
            get
            {
                return this.garageSlots;
            }
            private set
            {
                this.garageSlots = value;
            }
        }

        public bool IsFull
        {
            get
            {
                if (this.Products.Sum(p => p.Weight) == this.Capacity)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IReadOnlyCollection<Vehicle> Garage
        {
            get
            {
                return new ReadOnlyCollection<Vehicle>(this.garage);
            }
        }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }




        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            IVehicle vehicle = this.garage[garageSlot];
            //this.garage.RemoveAt(garageSlot);
            return (Vehicle)vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            if (!deliveryLocation.Garage.Any(g => g == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            int freeSlot = 0;
            foreach (var slot in deliveryLocation.garage)
            {
                
                if (slot == null)
                {
                    break;
                }
                freeSlot++;
            }
            deliveryLocation.garage[freeSlot] = vehicle;

            return freeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            IVehicle vehicleToUnload = GetVehicle(garageSlot);
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            int unloadedProducts = 0;

            for(int i = 0; i < vehicleToUnload.Trunk.Count; i++)
            {
                if (!vehicleToUnload.IsEmpty && !this.IsFull)
                {
                    Product product = vehicleToUnload.Unload();
                    this.products.Add(product);
                    unloadedProducts++;
                    
                }
                else
                {
                    break;
                    //throw new InvalidOperationException("Storage is full!");
                }

                //if (((this.Products.Sum(p => p.Weight)) <= this.Capacity))
                //{
                //    Product product = vehicleToUnload.Unload();
                //    this.products.Add(product);
                //    unloadedProducts++;

                //}
                //else
                //{
                //    break;
                //    //throw new InvalidOperationException("Storage is full!");
                //}

            }

            return unloadedProducts;

        }
    }
}
