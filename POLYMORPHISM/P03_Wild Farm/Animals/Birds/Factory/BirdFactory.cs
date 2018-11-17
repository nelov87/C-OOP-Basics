using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Animals.Birds.Factory
{
    public class BirdFactory
    {
        public Bird CreateBirds(string type, string name, double weight, double wingSize)
        {
            type = type.ToLower();

            switch (type)
            {
                case "hen":
                    return new Hen(name, weight, wingSize);
                case "owl":
                    return new Owl(name, weight, wingSize);
                default:
                    throw new ArgumentException("Invalid bird type!");
            }
        }
    }
}
