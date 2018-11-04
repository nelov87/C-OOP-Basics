using System;
using System.Collections.Generic;
using System.Text;

namespace P05_PizzaCalories
{
    public class Topping
    {
        private string typeOfToping;
        private decimal weight;
        private decimal caloriesOfToping;

        public Topping(string typeOfToping, decimal weight)
        {
            TypeOfToping = typeOfToping;
            Weight = weight;
            SetCalories();
        }

        public decimal CaloriesOfToping
        {
            get { return caloriesOfToping; }
            private set
            {
                caloriesOfToping = value;
            }
        }

        private void SetCalories()
        {
            caloriesOfToping = (2 * Weight) * Modifier;
        }

        private decimal Weight
        {
            get { return weight; }
            set
            {
                if (value > 0 && value <= 50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{TypeOfToping} weight should be in the range [1..50].");
                }
            }
        }

        private decimal Modifier { get; set; }

        private string TypeOfToping
        {
            get { return typeOfToping; }
            set
            {
                switch (value.ToLower())
                {
                    case "meat":
                        typeOfToping = value;
                        Modifier = 1.2M;
                        break;
                    case "veggies":
                        typeOfToping = value;
                        Modifier = 0.8M;
                        break;
                    case "cheese":
                        typeOfToping = value;
                        Modifier = 1.1M;
                        break;
                    case "sauce":
                        typeOfToping = value;
                        Modifier = 0.9M;
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                }
            }
        }

    }
}


   