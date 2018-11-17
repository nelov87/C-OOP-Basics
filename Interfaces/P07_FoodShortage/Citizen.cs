using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodShortage
{
    public class Citizen : IBuyer
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Age { get; set; }
        public string BurthDate { get; set; }
        public int Food { get; set; }

        public Citizen()
        {

        }

        public Citizen(string name, string age, string id, string burthDate)
        {
            Name = name;
            Id = id;
            Age = age;
            BurthDate = burthDate;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
