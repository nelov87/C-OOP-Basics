using StorageMaster.Factories;
using StorageMaster.Products;
using StorageMaster.StoragePlase;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Dictionary<string, Storage> storages;
        private StorageFactory storageFactory;
        private Dictionary<string, Stack<Product>> products;
        private ProductFactory productFactory;
        private Vehicle curentVehicle;

        public StorageMaster()
        {
            products = new Dictionary<string, Stack<Product>>();
            storages = new Dictionary<string, Storage>();
            storageFactory = new StorageFactory();
            productFactory = new ProductFactory();
        }


        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);

            if (this.products.ContainsKey(type))
            {
                this.products.Add(type, new Stack<Product>());
            }

            products[type].Push(product);

            string result = $"Added {type} to pool";
            return result;
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            storages.Add(name, storage);
            string result = $"Registered {name}";
            return result;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages[storageName];
            this.curentVehicle = storage.GetVehicle(garageSlot);
            string result = $"Selected {this.curentVehicle.GetType().Name}";
            return result;

        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProducts = 0;
            foreach (string productName in productNames)
            {
                if (curentVehicle.IsFull)
                {
                    break;
                }

                if (!this.products.ContainsKey(productName) || this.products[productName].Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                Product product = this.products[productName].Pop();
                this.curentVehicle.LoadProduct(product);

                loadedProducts++;
                
            }
            string result = $"Loaded {loadedProducts}/{productNames.Count()} products into {this.curentVehicle.GetType().Name}";
            return result;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storages.ContainsKey(sourceName))
            {
                throw new InvalidOperationException($"Invalid source storage!");
            }
            if (!this.storages.ContainsKey(destinationName))
            {
                throw new InvalidOperationException($"Invalid destination storage!");
            }
            Storage sorceStorage = this.storages[sourceName];
            Vehicle vehicle = sorceStorage.GetVehicle(sourceGarageSlot);
            Storage destinationStorage = this.storages[destinationName];
            int destinationGarageSlot = sorceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);
            string result = $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
            return result;





        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages[storageName];
            int unloadedProductsCounter = storage.UnloadVehicle(garageSlot);
            int countProductsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;
            string result = $"Unloaded {unloadedProductsCounter}/{countProductsInVehicle} products at {storageName}";
            return result;
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storages[storageName];
            Dictionary<string, int> productCounter = new Dictionary<string, int>();
            foreach (Product product in storage.Products)
            {
                string productTypeName = product.GetType().Name;

                if (!productCounter.ContainsKey(productTypeName))
                {
                    productCounter.Add(productTypeName, 1);
                }
                else
                {
                    productCounter[productTypeName]++;
                }

            }
            var productsSum = storage.Products.Sum(p => p.Weight);
            int storageCapacity = storage.Capacity;
            //Dictionary<string, int> sortedProducts = productCounter.OrderByDescending(p => p.Value).ThenBy(p => p.Key).ToDictionary(x => x.Key, x=> x.Value);

            //string[] productsAsString = new string[sortedProducts.Count()];

            //int index = 0;
            //foreach (var product in sortedProducts)
            //{
            //    string curentResult = $"{product.Key} ({product.Value})";
            //    productsAsString[index++] = curentResult;
            //}

            string[] productsAsString = productCounter
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .Select(kvp => $"{kvp.Key} ({kvp.Value})")
                .ToArray();

            string stockLine = $"Stock ({productsSum}/{storageCapacity}): [{string.Join(", ", productsAsString)}]";
            string[] storageStringRepresentation = storage
                .Garage
                .Select(g => g == null ? "empty" : g.GetType().Name)
                .ToArray();

            string garageLine = $"Garage: [{string.Join("|", storageStringRepresentation)}]";

            string result = stockLine + Environment.NewLine + garageLine;
            return result;
        }

        public string GetSummary()
        {
            double sum = 0;
            Storage[] sortedStorages = this.storages
                .Select(s => s.Value)
                 .OrderByDescending(s => s.Products.Sum(p => p.Price))
                 .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (Storage curentStore in sortedStorages)
            {
                double totalMony = curentStore.Products.Sum(p => p.Price);

                sb.AppendLine($"{curentStore.Name}");
                sb.AppendLine($"Storage worth: ${totalMony:F2}");
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
