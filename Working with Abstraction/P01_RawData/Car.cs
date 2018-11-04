using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {

        public string model;
        public Engine EngineStats = new Engine();
        //public int engineSpeed;// done
        //public int enginePower;// done
        public Cargo CargoStats = new Cargo();
        //public int cargoWeight;//done
        //public string cargoType;//done
        public List<Tire> Tires = new List<Tire>();
        //public KeyValuePair<double, int>[] tires;

        


        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            this.model = model;
            EngineStats.EngineSpeed = engineSpeed;
            EngineStats.EnginePower = enginePower;
            CargoStats.CargoWeight = cargoWeight;
            CargoStats.CargoType = cargoType;
            Tires.Add(new Tire(tire1Pressure, tire1Age));
            Tires.Add(new Tire(tire2Pressure, tire2Age));
            Tires.Add(new Tire(tire3Pressure, tire3age));
            Tires.Add(new Tire(tire4Pressure, tire4age));




            //this.tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };
        }
        
    }
}
