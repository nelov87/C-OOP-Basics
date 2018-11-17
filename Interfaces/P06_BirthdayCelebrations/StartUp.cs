using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_BirthdayCelebrations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBurthable> all = new List<IBurthable>();


            while (input != "End")
            {
                string[] tokens = input.Split(' ').ToArray();

                if (tokens.Length == 5 && tokens[0] == "Citizen")
                {
                    all.Add(new Citizen(tokens[1], tokens[2], tokens[3], tokens[4]));

                }
                else if (tokens.Length == 3 && tokens[0] == "Pet")
                {
                    all.Add(new Pet(tokens[1], tokens[2]));
                }

                input = Console.ReadLine();
            }

            string date = Console.ReadLine();

            all.Where(c => c.BurthDate.EndsWith(date))
                .Select(c => c.BurthDate)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
