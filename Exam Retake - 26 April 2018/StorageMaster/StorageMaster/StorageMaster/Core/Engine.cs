using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split().ToArray();
                string command = tokens[0];
                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            //{type} {price}
                            string productTypeToAdd = tokens[1];
                            double priceToAdd = double.Parse(tokens[2]);
                            result = storageMaster.AddProduct(productTypeToAdd, priceToAdd);
                            Console.WriteLine(result);
                            break;
                        case "RegisterStorage":
                            // {type} {name}
                            string storageTypeToAdd = tokens[1];
                            string nameToAdd = tokens[2];
                            result = storageMaster.RegisterStorage(storageTypeToAdd, nameToAdd);
                            Console.WriteLine(result);
                            break;
                        case "SelectVehicle":
                            // {storageName} {garageSlot}
                            string storageName = tokens[1];
                            int garageSlotToSelect = int.Parse(tokens[2]);
                            result = storageMaster.SelectVehicle(storageName, garageSlotToSelect);
                            Console.WriteLine(result);
                            break;
                        case "LoadVehicle":
                            // {productName1} {productName2} {productNameN}
                            string[] productsToAdd = tokens.Skip(1).ToArray();
                            result = storageMaster.LoadVehicle(productsToAdd);
                            Console.WriteLine(result);
                            break;
                        case "SendVehicleTo":
                            // {sourceName} {sourceGarageSlot} {destinationName}
                            string sourceName = tokens[1];
                            int sourceGarageSlot = int.Parse(tokens[2]);
                            string destinationName = tokens[2];
                            result = storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                            Console.WriteLine(result);
                            break;
                        case "UnloadVehicle":
                            // {storageName} {garageSlot}
                            string storageNameToUnload = tokens[1];
                            int garageSlot = int.Parse(tokens[2]);
                            result = storageMaster.UnloadVehicle(storageNameToUnload, garageSlot);
                            Console.WriteLine(result);
                            break;
                        case "GetStorageStatus":
                            // {storageName}
                            string storageNameStatus = tokens[1];
                            result = storageMaster.GetStorageStatus(storageNameStatus);
                            Console.WriteLine(result);
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"Error:{ioe.Message}");
                }
            }

            string summary = storageMaster.GetSummary();
            Console.WriteLine(summary);
        }
    }
}
