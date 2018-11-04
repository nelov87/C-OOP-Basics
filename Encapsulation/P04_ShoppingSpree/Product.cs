using System;
using System.Collections.Generic;
using System.Text;

namespace P04_ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.price = value;
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public Product()
        {

        }

    }
}
