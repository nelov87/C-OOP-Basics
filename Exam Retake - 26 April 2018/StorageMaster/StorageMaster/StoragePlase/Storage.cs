using StorageMaster.Products;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StorageMaster.StoragePlase
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private bool isFull;
        private Vehicle[] vehiclesList;
        private List<Product> productsList;
        private IReadOnlyCollection<Vehicle> garage;
        private IReadOnlyCollection<Product> products;

        public Storage(string name)
        {
            
            this.productsList = new List<Product>();
            this.Name = name;
            
        }

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles) : this(name)
        {
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.vehiclesList = new Vehicle[GarageSlots];
            FillGarageWithInitialVehicals(vehicles);
        }

        private void FillGarageWithInitialVehicals(IEnumerable<Vehicle> vehicles)
        {

            int index = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                this.vehiclesList[index] = vehicle;
                index++;
            }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots )
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            else if (vehiclesList[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            else
            {
                return vehiclesList[garageSlot];
            }
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);
            int foundSlot = deliveryLocation.AddVehicelToGarage(vehicle);
            vehiclesList[garageSlot] = null;
            //try
            //{


            //}
            //catch(InvalidOperationException ioe)
            //{
            // Console.WriteLine(ioe.Message);
            //}
            return foundSlot;
        }

        private int AddVehicelToGarage(Vehicle vehicle)
        {
            int freeGarageSlot = Array.IndexOf(vehiclesList, null);
            if (freeGarageSlot == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }


            vehiclesList[freeGarageSlot] = vehicle;
            return freeGarageSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            int unlodedProducts = 0;
            //try
            //{
                
                if (this.IsFull)
                {
                    throw new InvalidOperationException("Storage is full!");
                }
                
                Vehicle vehicleToUnload = GetVehicle(garageSlot);

                while(!this.IsFull && !vehicleToUnload.IsEmpty)
                {
                    unlodedProducts++;
                    this.productsList.Add(vehicleToUnload.Unload());
                }
                
            //}
            //catch (InvalidOperationException ioe)
            //{
                //Console.WriteLine(ioe.Message);
            //}

            return unlodedProducts;
            
        }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return productsList.AsReadOnly();
            }
            
        }



        public IReadOnlyCollection<Vehicle> Garage
        {
            get
            {
                return Array.AsReadOnly(vehiclesList);
            }
            
        }


        public bool IsFull
        {
            get
            {
                if (this.Products.Sum(p => p.Weight) >= Capacity)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }


        public int GarageSlots
        {
            get { return garageSlots; }
            set { garageSlots = value; }
        }


        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }



        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
