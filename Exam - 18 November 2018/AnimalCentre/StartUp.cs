using AnimalCentre.Core;
using AnimalCentre.Core.Contracts;
using AnimalCentre.IO;
using AnimalCentre.IO.Contracts;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IEngine engine = new Engine(reader, writer);

            engine.Run();
            
        }
    }
}
