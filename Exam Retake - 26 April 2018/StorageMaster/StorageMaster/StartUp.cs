using StorageMaster.Core;
using System;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new StorageMaster.Core.StorageMaster());
            engine.Run();
        }
    }
}
