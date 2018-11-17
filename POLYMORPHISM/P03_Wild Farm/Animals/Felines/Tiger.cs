using P03_Wild_Farm.Foods;
using System;

namespace P03_Wild_Farm.Animals
{
    public class Tiger : Feline
    {
        private const double increasWith = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }

        
        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * increasWith;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            
        }
    }
}
