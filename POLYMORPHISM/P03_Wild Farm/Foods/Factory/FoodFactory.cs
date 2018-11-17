using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Foods.Factory
{
    public class FoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            type = type.ToLower();

            switch (type)
            {
                case "fruit":
                    return new Fruit(quantity);
                case "vegetable":
                    return new Vegetable(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException("Invalid type of food");
            }
        }
    }
}
