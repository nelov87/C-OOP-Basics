using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Ferrari
{
    interface ICar
    {
        string Model { get; set; }
        string DriverName { get; set; }

        string PushBrake();
        string PushGas();
    }
}
