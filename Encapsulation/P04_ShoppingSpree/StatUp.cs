using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_ShoppingSpree
{
    public class StatUp
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] stock = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string ,Person> people = new Dictionary<string, Person>();
            people = FillPeple(names);
            if (people.Count == 0)
            {
                return;
            }
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            products = FillProducts(stock);
            if (products.Count == 0)
            {
                return;
            }

            string comands = Console.ReadLine();

            while (comands != "END")
            {
                string[] tokes = comands.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string person = tokes[0];
                string product = tokes[1];
                if (!products.ContainsKey(product) || !people.ContainsKey(person))
                {
                    comands = Console.ReadLine();
                    continue;
                }

                if (!people[person].BuyProduct(products[product]))
                {
                    Console.WriteLine($"{people[person].Name} can't afford {products[product].Name}");
                }
                else
                {
                    Console.WriteLine($"{people[person].Name} bought {products[product].Name}");
                }

                comands = Console.ReadLine();
            }

            foreach (var person in people)
            {
                string productsBought = person.Value.Bag.Count == 0 ? "Nothing bought" : String.Join(", ", person.Value.Bag.Select(p => p));

                Console.WriteLine($"{person.Value.Name} - {productsBought}");
            }
        }

        private static Dictionary<string, Product> FillProducts(string[] stock)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            

            for (int i = 0; i < stock.Length; i++)
            {
                Product product = new Product();
                string[] productPriceArray = stock[i].Split('=').ToArray();
                if (productPriceArray.Length == 1)
                {
                    //continue;
                    return new Dictionary<string, Product>();
                }
                try
                {
                    decimal result = -1M;
                    decimal tryPars = 0;
                    bool checker = decimal.TryParse(productPriceArray[1], out tryPars);
                    if (checker)
                    {
                        result = decimal.Parse(productPriceArray[1]);
                    }
                    product.Name = productPriceArray[0];
                    product.Price = result;
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return new Dictionary<string, Product>();
                }

                products.Add(product.Name ,product);
            }

            return products;
        }

        private static Dictionary<string, Person> FillPeple(string[] names)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            for (int i = 0; i < names.Length; i++)
            {
                Person person = new Person();
                string[] nameMonyArray = names[i].Split('=').ToArray();
                try
                {
                    decimal result = -1M;
                    decimal tryParse = 0;
                    bool checker = decimal.TryParse(nameMonyArray[1], out tryParse);
                    if (checker)
                    {
                        result = decimal.Parse(nameMonyArray[1]);
                    }
                    person.Name = nameMonyArray[0];
                    person.Mony = result;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return new Dictionary<string, Person>();
                    
                }
                people.Add(person.Name ,person);
            }


            return people;
        }
    }
}
