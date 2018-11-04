using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace P05_PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> topings;
        private decimal totalCalories;

        public Pizza()
        {
            topings = new List<Topping>();
        }

        public Pizza(Dough dough)
        {
            Dough = dough;
        }

        public Pizza(Topping topping)
        {
            Topings.Add(topping);
        }

        public Pizza( string name)
        {
            Name = name;
        }

        

        public List<Topping> Topings
        {
            get { return topings; }
            set
            {
                if (topings.Count <= 10)
                {
                    topings = value;
                }
                else
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
            }
        }


        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                else
                {
                    name = value;
                }
            }
        }

        public decimal TotalCalories
        {
            get
            {
                FinishPizza();
                return totalCalories;
            }
            private set
            {

                totalCalories = value;
            }
        }

        private void FinishPizza()
        {
            TotalCalories = Dough.CaloriesPerGram + Topings.Sum(t => t.CaloriesOfToping);
        }
    }
}
