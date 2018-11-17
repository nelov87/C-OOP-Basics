using P03_Wild_Farm.Foods;
using System;
using System.Collections.Generic;
using System.Text;


namespace P03_Wild_Farm.Animals
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        void AskForFood();
        void Eat(Food food);
    }
}
