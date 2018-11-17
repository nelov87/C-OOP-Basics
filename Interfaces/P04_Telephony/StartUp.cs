using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Telephony
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split(' ').ToList();
            List<string> sites = Console.ReadLine().Split(' ').ToList();

            Phone smartphone = new Phone();

            foreach (var number in numbers)
            {
                Console.WriteLine(smartphone.Call(number));
            }

            foreach (var site in sites)
            {
                Console.WriteLine(smartphone.Browse(site));
            }

            

        }
    }
}
