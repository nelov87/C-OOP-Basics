﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        private const decimal AlcoholPrice = 3.50M;

        public Alcohol(string name, int servingSize,  string brand) : base(name, servingSize, AlcoholPrice, brand)
        {
            
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:F2}lv";
        }
    }
}
