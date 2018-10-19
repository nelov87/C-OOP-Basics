using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ////////////////// 1 //////////////////
            //list<person> persons = new list<person>();
            //persons.add(new person("pesho", 20));
            //persons.add(new person("gosho", 18));
            //persons.add(new person("stamat", 43));

            //foreach (Person person in persons)
            //{
            //    Console.WriteLine(person.Name + " -> " + person.Age);
            //}

            ////////////////// 3 //////////////////

            //int n = int.Parse(Console.ReadLine());
            //Family family = new Family();

            //for (int i = 0; i < n; i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            //    Person newPerson = new Person();
            //    newPerson.Name = input[0];
            //    newPerson.Age = int.Parse(input[1]);
            //    family.AddMember(newPerson);

            //}

            //foreach (Person person in family.FamilyList.Where( p => p.Age > 30).OrderBy(p => p.Name))
            //{
            //    Console.WriteLine($"{person.Name} - {person.Age}");
            //}

            ////////////////// 5 //////////////////

            //string first = Console.ReadLine();
            //string second = Console.ReadLine();
            //DateModifier dateModifier = new DateModifier(first, second);


            //Console.WriteLine(Math.Abs(dateModifier.ReturnDifrence()));

            ////////////////// 6 //////////////////

            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string name = "";
                decimal salary = 0;
                string position = "";
                string department = "";
                string email = "";
                int age = 0;

                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input.Length < 6 && input.Length == 4)
                {
                    name = input[0];
                    salary = decimal.Parse(input[1]);
                    position = input[2];
                    department = input[3];
                    Employee employee = new Employee(name, salary, position, department);

                    employees.Add(employee);
                }
                
            }


        }
    }
}
