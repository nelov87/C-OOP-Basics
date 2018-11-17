using StorageMaster.Products;
using System;
using System.Collections.Generic;
using System.Text;


namespace StorageMaster.Interfaces
{
    public interface IVehicle
    {
        int Capacity { get; }
        IReadOnlyCollection<Product> Trunk { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }

        void LoadProduct(Product product);
    }
}
