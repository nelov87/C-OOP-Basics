using P03_Wild_Farm.Foods;
using System;

namespace P03_Wild_Farm.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public int FoodEaten
        {
            get
            {
                return foodEaten;
            }
            set
            {
                foodEaten = value;
            }
        }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public virtual void AskForFood()
        {
            Console.WriteLine("Give me food");
        }

        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
