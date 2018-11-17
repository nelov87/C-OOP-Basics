using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Animals.Felines.Factory
{
    public class FelinesFactory
    {
        public Feline CreateFeline(string type, string name, double weight, string livingRegion, string breed)
        {
            type = type.ToLower();

            switch (type)
            {
                case "cat":
                    return new Cat(name, weight, livingRegion, breed);
                case "tiger":
                    return new Tiger(name, weight, livingRegion, breed);
                default:
                    throw new ArgumentException("Invalid feline type!");
            }
        }
    }
}
