
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Foods
{
    public class Food : IFood
    {
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

    }
}
