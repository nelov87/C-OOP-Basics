using System;
using System.Collections.Generic;
using System.Text;
using P03_Wild_Farm.Foods;

namespace P03_Wild_Farm.Animals
{
    class Hen : Bird
    {
        private const double invcreaseWith = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }
        
        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * invcreaseWith;
            this.FoodEaten += food.Quantity;
        }
    }
}
