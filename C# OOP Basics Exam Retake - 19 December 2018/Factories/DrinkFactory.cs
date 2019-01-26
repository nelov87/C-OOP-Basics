using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class DrinkFactory
    {
        public IDrink Create(string type, string name, int servingSize, string brand)
        {
            switch (type)
            {
                case "Alcohol":
                    IDrink alcohol = new Alcohol(name, servingSize, brand);
                    return alcohol;

                case "FuzzyDrink":
                    IDrink fuzzyDrink = new FuzzyDrink(name, servingSize, brand);
                    return fuzzyDrink;

                case "Juice":
                    IDrink juice = new Juice(name, servingSize, brand);
                    return juice;

                case "Water":
                    IDrink water = new Water(name, servingSize, brand);
                    return water;

                default:
                    return null;

            }
        }
    }
}
