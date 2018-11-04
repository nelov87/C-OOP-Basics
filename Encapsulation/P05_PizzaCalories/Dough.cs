using System;
using System.Collections.Generic;
using System.Text;

namespace P05_PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private decimal weight;
        private decimal caloriesPerGram;
        private decimal DoughModifier { get; set; }
        private decimal BakingModifier { get; set; }

        public Dough(string flourType, string bakingTechnique, decimal weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;

            SetCalories();
        }

        private void SetCalories()
        {
            caloriesPerGram = (2 * weight) * DoughModifier * BakingModifier;
        }

        public decimal CaloriesPerGram
        {
            get { return caloriesPerGram; }
            private set
            {
                caloriesPerGram = value;
            }
        }


        private decimal Weight
        {
            get { return weight; }
            set
            {
                if (value > 0 && value <= 200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }


        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                switch (value.ToLower())
                {
                    case "crispy":
                        bakingTechnique = value;
                        BakingModifier = 0.9M;
                        break;
                    case "chewy":
                        bakingTechnique = value;
                        BakingModifier = 1.1M;
                        break;
                    case "homemade":
                        bakingTechnique = value;
                        BakingModifier = 1.0M;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");

                }
            }
        }


        private string FlourType
        {
            get { return flourType; }
            set
            {
                switch(value.ToLower())
                {
                    case "white":
                        flourType = value;
                        DoughModifier = 1.5M;
                        break;
                    case "wholegrain":
                        flourType = value;
                        DoughModifier = 1.0M;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                        
                }
            }
        }

    }
}
