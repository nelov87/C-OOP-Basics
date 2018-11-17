using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IIdentifaiable> all = new List<IIdentifaiable>();


            while (input != "End")
            {
                string[] tokens = input.Split(' ').ToArray();

                if (tokens.Length == 3)
                {
                    all.Add(new Citizen(tokens[0], tokens[1], tokens[2]));

                }
                else if (tokens.Length == 2)
                {
                    all.Add(new Robot(tokens[0], tokens[1]));
                }

                input = Console.ReadLine();
            }

            string lastDigits = Console.ReadLine();

            all.Where(c => c.Id.EndsWith(lastDigits))
                .Select(c => c.Id)
                .ToList()
                .ForEach(Console.WriteLine);

            //foreach (var citizen in all)
            //{
            //    if (citizen.Id.EndsWith(lastDigits))
            //    {
            //        Console.WriteLine(citizen.Id);
            //    }
            //}
        }
    }
}
