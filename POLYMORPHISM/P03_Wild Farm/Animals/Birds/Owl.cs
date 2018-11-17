using P03_Wild_Farm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Animals
{
    public class Owl : Bird
    {
        private const double increaseWith = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }

        

        public override void Eat(Food food)
        {

            if (food is Meat)
            {
                this.Weight += food.Quantity * increaseWith;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            
        }
    }
}
