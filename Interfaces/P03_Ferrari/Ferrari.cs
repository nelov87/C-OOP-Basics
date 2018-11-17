using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Ferrari
{
    class Ferrari : ICar
    {
        public string Model { get ; set; }
        public string DriverName { get; set; }

        public Ferrari(string driversName)
        {
            Model = "488-Spider";
            DriverName = driversName;
        }

        public string PushBrake()
        {
            return "Brakes!";
        }

        public string PushGas()
        {
            return "Zadu6avam sA!";
        }
    }
}
