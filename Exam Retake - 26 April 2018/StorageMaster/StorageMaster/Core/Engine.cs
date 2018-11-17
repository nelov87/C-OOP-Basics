﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private bool isRunning;
        private StorageMaster storageMaster;

        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split();
                string output = "";

                try
                {
                    switch (tokens[0])
                    {
                        case "AddProduct":
                            string type = tokens[1];
                            double price = double.Parse(tokens[2]);

                            output = this.storageMaster.AddProduct(type, price);
                            break;
                        case "RegisterStorage":
                            type = tokens[1];
                            string name = tokens[2];

                            output = this.storageMaster.RegisterStorage(type, name);
                            break;
                        case "SelectVehicle":
                            string storageName = tokens[1];
                            int garageSlot = int.Parse(tokens[2]);

                            output = this.storageMaster.SelectVehicle(storageName, garageSlot);
                            break;
                        case "LoadVehicle":
                            output = this.storageMaster.LoadVehicle(tokens.Skip(1));
                            break;
                        case "SendVehicleTo":
                            string sourceName = tokens[1];
                            int sourceGarageSlot = int.Parse(tokens[2]);
                            string destinationName = tokens[3];

                            output = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                            break;
                        case "UnloadVehicle":
                            storageName = tokens[1];
                            garageSlot = int.Parse(tokens[2]);

                            output = this.storageMaster.UnloadVehicle(storageName, garageSlot);
                            break;
                        case "GetStorageStatus":
                            storageName = tokens[1];

                            output = this.storageMaster.GetStorageStatus(storageName);
                            break;
                        case "END":
                            output = this.storageMaster.GetSummary();
                            this.isRunning = false;
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"Error: {ioe.Message}");
                }

                Console.WriteLine(output);
            }
        }
    }
}
