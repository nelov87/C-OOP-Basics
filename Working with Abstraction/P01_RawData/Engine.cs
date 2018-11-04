using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }

        public Engine()
        {
                
        }

        public Engine(int engineSpeed, int enginePower)
        {
            EnginePower = enginePower;
            EngineSpeed = engineSpeed;
        }

    }
}
