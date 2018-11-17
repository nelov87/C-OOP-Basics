using System;

namespace P03_Ferrari
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Ferrari ferrari = new Ferrari(name);
            Console.WriteLine($"{ferrari.Model}/{ferrari.PushBrake()}/{ferrari.PushGas()}/{ferrari.DriverName}");
        }
    }
}
