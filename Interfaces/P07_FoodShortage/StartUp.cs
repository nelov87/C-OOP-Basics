using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FoodShortage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();

                if (input.Length == 4)
                {
                    buyers.Add(new Citizen(input[0], input[1], input[2], input[3]));
                }
                else if (input.Length == 3)
                {
                    buyers.Add(new Rebel(input[0], input[1], input[2]));
                }
            }
            string name = Console.ReadLine();
            while (name != "End")
            {
                var buyer = buyers.SingleOrDefault(c => c.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
                name = Console.ReadLine();
            }

            int sum = buyers.Sum(c => c.Food);
            Console.WriteLine(sum);
        }
    }
}
