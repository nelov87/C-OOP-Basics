using P03_Wild_Farm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Animals
{
    public class Dog : Mammal
    {
        private const double increaseWith = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
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
