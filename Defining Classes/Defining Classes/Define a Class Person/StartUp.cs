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

            //int n = int.Parse(Console.ReadLine());
            //List<Employee> employees = new List<Employee>();

            //for (int i = 0; i < n; i++)
            //{
            //    string name = "";
            //    decimal salary = 0;
            //    string position = "";
            //    string department = "";
            //    string email = "n/a";
            //    int age = -1;

            //    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            //    if (input.Length == 4)
            //    {
            //        name = input[0];
            //        salary = decimal.Parse(input[1]);
            //        position = input[2];
            //        department = input[3];

            //        Employee employee = new Employee(name, salary, position, department, email, age);

            //        employees.Add(employee);
            //    }
            //    if (input.Length == 5 )
            //    {
            //        name = input[0];
            //        salary = decimal.Parse(input[1]);
            //        position = input[2];
            //        department = input[3];
            //        if (input[4].Contains("@"))
            //        {
            //            email = input[4];
            //        }
            //        else
            //        {
            //            age = int.Parse(input[4]);
            //        }

            //        Employee employee = new Employee(name, salary, position, department, email, age);

            //        employees.Add(employee);
            //    }
            //    if (input.Length == 6)
            //    {
            //        name = input[0];
            //        salary = decimal.Parse(input[1]);
            //        position = input[2];
            //        department = input[3];
            //        email = input[4];
            //        age = int.Parse(input[5]);

            //        Employee employee = new Employee(name, salary, position, department, email, age);

            //        employees.Add(employee);
            //    }

            //}
            //SortedDictionary<string, decimal> departments = new SortedDictionary<string, decimal>();

            //string bestPaidDept = employees
            //    .GroupBy(e => e.Department)
            //    .Select(g => new { Department = g.Key, AvgSalary = g.Average(e => e.Salary) })
            //    .OrderByDescending(o => o.AvgSalary)
            //    .First()
            //    .Department;

            //Console.WriteLine($"Highest Average Salary: {bestPaidDept}");

            //employees
            //    .Where(e => e.Department == bestPaidDept)
            //    .OrderByDescending(e => e.Salary)
            //    .ToList()
            //    .ForEach(Console.WriteLine);

            ////////////////// 7 /////////////////
            ///

            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split();

                cars.Add(new Car(tokens[0], decimal.Parse(tokens[1]), decimal.Parse(tokens[2])));
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split();

                string model = tokens[1];
                int distance = int.Parse(tokens[2]);

                Car car = cars.First(c => c.Model == model);

                if (!car.Drive(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            cars.ForEach(Console.WriteLine);


        }
    }
}
