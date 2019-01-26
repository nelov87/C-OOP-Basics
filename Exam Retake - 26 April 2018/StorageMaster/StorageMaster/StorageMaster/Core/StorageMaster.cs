using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private IList<IProduct> productPool;
        private IDictionary<string, IStorage> storagesRegister;
        private IVehicle curentVehicle;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.productPool = new List<IProduct>();
            this.storagesRegister = new Dictionary<string, IStorage>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            
            IProduct product = productFactory.CreateProduct(type, price);
            //if (product == null)
            //{
            //    throw new InvalidOperationException("Invalid product type!");
            //}

            this.productPool.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            IStorage storage = storageFactory.CreateStorage(type, name);

            //if (storage == null)
            //{
            //    throw new InvalidOperationException("Invalid storage type!");
            //}
            this.storagesRegister.Add(name, storage);
            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            this.curentVehicle = this.storagesRegister[storageName].GetVehicle(garageSlot);
            return $"Selected {curentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedCount = 0;
            
            foreach (string product in productNames)
            {
                
                IProduct productToLoad = this.productPool.LastOrDefault(p => p.GetType().Name == product);
                if(productToLoad == null)
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }
                if ((this.curentVehicle.Trunk.Sum(p => p.Weight) + productToLoad.Weight) > this.curentVehicle.Capacity)
                {
                    break;
                }
                this.productPool.RemoveAt(this.productPool.IndexOf(productToLoad));

                this.curentVehicle.LoadProduct((Product)productToLoad);
                loadedCount++;

            }

            return $"Loaded {loadedCount}/{productNames.Count()} products into {curentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storagesRegister.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!this.storagesRegister.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            IVehicle vehicle = this.storagesRegister[sourceName].GetVehicle(sourceGarageSlot);

            int destinationSlot = this.storagesRegister[sourceName].SendVehicleTo(sourceGarageSlot, (Storage)this.storagesRegister[destinationName]);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            IVehicle vehicle = this.storagesRegister[storageName].GetVehicle(garageSlot);
            int productsToUnload = vehicle.Trunk.Count;
            int unloadedProducts = this.storagesRegister[storageName].UnloadVehicle(garageSlot);
                
            

            return $"Unloaded {unloadedProducts}/{productsToUnload} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            StringBuilder sb = new StringBuilder();
            IStorage storage = this.storagesRegister[storageName];
            double sumOfProducts = storage.Products.Sum(p => p.Weight);
            Dictionary<string, int> productCountPair = new Dictionary<string, int>();

            foreach (var product in storage.Products)
            {
                if (!productCountPair.ContainsKey(product.GetType().Name))
                {
                    productCountPair.Add(product.GetType().Name, 0);
                }
                else
                {
                    productCountPair[product.GetType().Name]++;
                }
            }
            sb.Append($"Stock ({sumOfProducts}/{storage.Capacity}): ");
            string[] arr = new string[productCountPair.Count];
            int count = 0;
            foreach (var item in productCountPair.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                arr[count] = $"{item.Key} ({item.Value})";
                count++;
            }
            
            sb.Append($"[{string.Join(", ", arr)}]");
            sb.Append("\n");
            sb.Append("Garage: ");
            string[] arrVehicles = new string[storage.GarageSlots];
            int counter = 0;
            foreach(var vehicle in storage.Garage)
            {
                if (vehicle == null)
                {
                    arrVehicles[0] = "empty";
                }
                else
                {
                    arrVehicles[0] = vehicle.GetType().Name;
                }
            }
            sb.Append($"[{string.Join("|", arrVehicles)}]");
            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            var sortedStorage = this.storagesRegister.Values
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .ToArray();

            foreach (var storage in sortedStorage)
            {
                sb.AppendLine($"{storage.Name}:");
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }
    }
}
