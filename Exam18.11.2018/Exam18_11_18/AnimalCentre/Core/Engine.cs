using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCentre;
        public Engine()
        {
            animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string[] inputArgs = Console.ReadLine().Split();

            while (inputArgs[0] != "End")
            {
                try
                {
                    switch (inputArgs[0])
                    {
                        case "RegisterAnimal":
                            string type = inputArgs[1];
                            string name = inputArgs[2];
                            int energy = int.Parse(inputArgs[3]);
                            int hapiness = int.Parse(inputArgs[4]);
                            int procedurTime = int.Parse(inputArgs[5]);

                            string result = animalCentre.RegisterAnimal(type, name, energy, hapiness, procedurTime);
                            Console.WriteLine(result);
                            result = "";
                            break;
                        case "Chip":
                            name = inputArgs[1];
                            procedurTime = int.Parse(inputArgs[2]);
                            result = animalCentre.Chip(name, procedurTime);
                            Console.WriteLine(result);
                            result = "";
                            break;
                        case "Vaccinate":
                            name = inputArgs[1];
                            procedurTime = int.Parse(inputArgs[2]);
                            result = animalCentre.Vaccinate(name, procedurTime);
                            Console.WriteLine(result);
                            result = "";
                            break;
                        case "Fitness":
                            name = inputArgs[1];
                            procedurTime = int.Parse(inputArgs[2]);
                            result = animalCentre.Fitness(name, procedurTime);
                            Console.WriteLine(result);
                            result = "";
                            break;
                        case "Play":
                            name = inputArgs[1];
                            procedurTime = int.Parse(inputArgs[2]);
                            result = animalCentre.Play(name, procedurTime);
                            Console.WriteLine(result);
                            result = "";
                            break;
                        case "DentalCare":
                            name = inputArgs[1];
                            procedurTime = int.Parse(inputArgs[2]);
                            result = animalCentre.DentalCare(name, procedurTime);
                            Console.WriteLine(result);
                            result = "";
                            break;
                        case "NailTrim":
                            name = inputArgs[1];
                            procedurTime = int.Parse(inputArgs[2]);
                            result = animalCentre.NailTrim(name, procedurTime);
                            Console.WriteLine(result);
                            result = "";
                            break;
                        case "Adopt":
                            name = inputArgs[1];
                            string owner = inputArgs[2];
                            result = animalCentre.Adopt(name, owner);
                            Console.WriteLine(result);
                            result = "";
                            break;
                        case "History":
                            string procedureType = inputArgs[1];

                            result = animalCentre.History(procedureType);
                            Console.WriteLine(result);
                            result = "";
                            break;
                    }
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine($"ArgumentException: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"InvalidOperationException: {ioe.Message}");
                }

                inputArgs = Console.ReadLine().Split();
            }

            foreach (var owners in animalCentre.AnimalsInHotel.OrderBy(x => x.Owner))
            {
                Console.WriteLine($"--Owner: {owners.Owner}");
                Console.Write($"    - Adopted animals: ");
                List<string> adopAnimArr = new List<string>();
                foreach (var animalll in animalCentre.AnimalsInHotel.OrderBy(x => x.Name))
                {
                    adopAnimArr.Add(animalll.Name);
                }
                Console.WriteLine($"{string.Join(", ", adopAnimArr)}");
            }
        }
    }
}


    //• RegisterAnimal {type} {name} {energy} {happiness} {procedureTime}
    //• Chip {name} {procedureTime}
    //• Vaccinate {name} {procedureTime}
    //• Fitness {name} {procedureTime}
    //• Play {name} {procedureTime}
    //• DentalCare {name} {procedureTime}
    //• NailTrim {name} {procedureTime}
    //• Adopt {animal name} {owner}
    //• History {procedureType}