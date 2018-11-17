using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodShortage
{
    public class Rebel : IBuyer
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Organization { get; set; }
        public int Food { get; set; }

        public Rebel()
        {

        }
        public Rebel(string name, string age, string organization)
        {
            Name = name;
            Age = age;
            Organization = organization;
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
