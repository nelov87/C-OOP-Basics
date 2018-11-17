using P03_Wild_Farm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Animals
{
    public class Cat : Feline
    {
        private const double increaseWith = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }

        

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
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
