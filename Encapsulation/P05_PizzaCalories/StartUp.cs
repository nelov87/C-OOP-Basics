using System;
using System.Linq;
using System.Collections.Generic;

namespace P05_PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizzas = new Pizza();
            string input = Console.ReadLine();
            bool checkForExeptions = false;

            while (input != "END")
            {
                string[] comands = input.Split(new char[] { ' ' }).ToArray();

                if (comands[0] == "Dough")
                {
                    try
                    {
                        Dough dough = new Dough(comands[1], comands[2], decimal.Parse(comands[3]));
                        pizzas.Dough = dough;

                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        checkForExeptions = true;
                    }

                }
                else if (comands[0] == "Topping")
                {
                    try
                    {
                        Topping topping = new Topping(comands[1], decimal.Parse(comands[2]));
                        if (pizzas.Topings.Count <= 10)
                        {
                            pizzas.Topings.Add(topping);
                        }
                        else
                        {
                            checkForExeptions = true;
                            throw new ArgumentException("Number of toppings should be in range [0..10].");
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        checkForExeptions = true;
                    }
                }
                else if (comands[0] == "Pizza")
                {
                    try
                    {
                        pizzas.Name = comands[1];
                    }
                    catch (ArgumentException e)
                    {
                        checkForExeptions = true;
                        Console.WriteLine(e.Message);
                    }
                }
                if (checkForExeptions)
                {
                    break;
                }

                input = Console.ReadLine();

            }

            if (!checkForExeptions)
            {
                Console.WriteLine($"{pizzas.Name} - {pizzas.TotalCalories:F2} Calories.");
            }
        }
    }
}
