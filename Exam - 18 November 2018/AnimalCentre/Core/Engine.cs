using AnimalCentre.Core.Contracts;
using AnimalCentre.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private AnimalCentre animalCentre;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string input = reader.ReadLine();

            while (input != "End")
            {
                string[] inputArr = input.Split(" ").Take(1).ToArray();
                string command = inputArr[0];
                string[] arguments = input.Split().Skip(1).ToArray();
                string result = string.Empty;
                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            //{type} {name} {energy} {happiness} {procedureTime}
                            string type = arguments[0];
                            string name = arguments[1];
                            int energy = int.Parse(arguments[2]);
                            int happiness = int.Parse(arguments[3]);
                            int procedureTime = int.Parse(arguments[4]);
                            result = this.animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);

                            break;
                        case "Chip":
                            //{name} {procedureTime}
                            name = arguments[0];
                            procedureTime = int.Parse(arguments[1]);
                            result = this.animalCentre.Chip(name, procedureTime);

                            break;
                        case "Vaccinate":
                            //{name} {procedureTime}
                            name = arguments[0];
                            procedureTime = int.Parse(arguments[1]);
                            result = this.animalCentre.Vaccinate(name, procedureTime);

                            break;
                        case "Fitness":
                            //{name} {procedureTime}
                            name = arguments[0];
                            procedureTime = int.Parse(arguments[1]);
                            result = this.animalCentre.Fitness(name, procedureTime);

                            break;
                        case "Play":
                            //{name} {procedureTime}
                            name = arguments[0];
                            procedureTime = int.Parse(arguments[1]);
                            result = this.animalCentre.Play(name, procedureTime);

                            break;
                        case "DentalCare":
                            //{name} {procedureTime}
                            name = arguments[0];
                            procedureTime = int.Parse(arguments[1]);
                            result = this.animalCentre.DentalCare(name, procedureTime);

                            break;
                        case "NailTrim":
                            //{name} {procedureTime}
                            name = arguments[0];
                            procedureTime = int.Parse(arguments[1]);
                            result = this.animalCentre.NailTrim(name, procedureTime);

                            break;
                        case "Adopt":
                            //{animal name} {owner}
                            name = arguments[0];
                            string owner = arguments[1];
                            result = this.animalCentre.Adopt(name, owner);

                            break;
                        case "History":
                            //{procedureType}
                            string procedureType = arguments[0];
                            result = this.animalCentre.History(procedureType);

                            break;
                    }
                    
                }
                catch (ArgumentException ae)
                {
                    result = $"ArgumentException: {ae.Message}";
                }
                catch (InvalidOperationException ioe)
                {
                    result = $"InvalidOperationException: {ioe.Message}";

                }
                writer.WriteLine(result);

                input = reader.ReadLine();
            }

            StringBuilder sb = new StringBuilder();
            foreach (var owner in animalCentre.AdoptedAnimls.OrderBy(o => o.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" " ,owner.Value)}");
            }
            sb.ToString().TrimEnd();
            Console.WriteLine(sb);
        }
    }
}
