using System;
using System.Collections.Generic;
using System.Text;

namespace P04_ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal mony;
        private List<string> bag;

        public List<string> Bag
        {
            get { return bag; }
            set { bag = value; }
        }


        public decimal Mony
        {
            get { return mony; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    this.mony = value;
                }

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
                else
                {
                    this.name = value;
                }
            }
        }

        public Person()
        {
            Bag = new List<string>();
        }

        public bool BuyProduct(Product product)
        {
            if (Mony < product.Price)
            {
                return false;
            }
            
            Bag.Add(product.Name);
            Mony -= product.Price;

            return true;
            
        }

    }
}
