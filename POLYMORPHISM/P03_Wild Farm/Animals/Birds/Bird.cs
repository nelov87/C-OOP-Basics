﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Animals
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get
            {
                return wingSize;
            }
            set
            {
                wingSize = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }

    }
}

//{Type} {Name} {Weight} {WingSize}
