using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public IStorage CreateStorage(string type, string name)
        {
            IStorage storage;
            switch (type)
            {
                case "AutomatedWarehouse":
                    storage = new AutomatedWarehouse(name);
                    return storage;
                case "DistributionCenter":
                    storage = new DistributionCenter(name);
                    return storage;
                case "Warehouse":
                    storage = new Warehouse(name);
                    return storage;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }
        }
    }
}
