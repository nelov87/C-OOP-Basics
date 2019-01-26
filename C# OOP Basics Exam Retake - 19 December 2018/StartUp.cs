using SoftUniRestaurant.Core;
using SoftUniRestaurant.IO;
using SoftUniRestaurant.IO.Contracts;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();
            IEngine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
