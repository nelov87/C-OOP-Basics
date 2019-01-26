using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory
    {
        public IFood Create(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    IFood desert = new Dessert(name, price);
                    return desert;
                    
                case "MainCourse":
                    IFood mainCourse = new MainCourse(name, price);
                    return mainCourse;

                case "Salad":
                    IFood salad = new Salad(name, price);
                    return salad;

                case "Soup":
                    IFood soup = new Soup(name, price);
                    return soup;

                default:
                    return null;

            }
        }
    }
}
