using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Dictionary<string, Animal> animalsInHotel;
        private List<Procedure> procedures;

        public AnimalCentre()
        {
            animalsInHotel = new Dictionary<string, Animal>();
            procedures = new List<Procedure>();
        }

        public IReadOnlyCollection<Animal> AnimalsInHotel
        {
            get
            {
                IReadOnlyCollection<Animal> animalss = animalsInHotel.Values.ToArray();
                return animalss;
            }
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (energy < 0 || energy > 100)
            {
                throw new ArgumentException("Invalid energy");
            }
            if (happiness < 0 || happiness > 100)
            {
                throw new ArgumentException("Invalid happiness");
            }
            if (animalsInHotel.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} already exist");
            }
            
            switch (type)
            {
                case "Cat":
                    Animal curentCat = new Cat(name, energy,happiness, procedureTime);
                    animalsInHotel.Add(name ,curentCat);
                    break;
                case "Dog":
                    Animal curentDog = new Dog(name, energy, happiness, procedureTime);
                    animalsInHotel.Add(name, curentDog);
                    break;
                case "Lion":
                    Animal curentLion = new Lion(name, energy, happiness, procedureTime);
                    animalsInHotel.Add(name, curentLion);
                    break;
                case "Pig":
                    Animal curentPig = new Pig(name, energy, happiness, procedureTime);
                    animalsInHotel.Add(name, curentPig);
                    break;
            }
            string result = $"Animal {name} registered successfully";
            return result;

        }

        public string Chip(string name, int procedureTime)
        {
            if (IsExistInHotel(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            Procedure procedure = new Chip();
            procedure.DoService(animalsInHotel[name], procedureTime);
            procedures.Add(procedure);
            string result = $"{name} had chip procedure";
            return result;

        }

        private bool IsExistInHotel(string name)
        {
            return !animalsInHotel.ContainsKey(name);
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (IsExistInHotel(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            Procedure procedure = new Vaccinate();
            procedure.DoService(animalsInHotel[name], procedureTime);
            procedures.Add(procedure);
            string result = $"{name} had vaccination procedure";
            return result;
        }

        public string Fitness(string name, int procedureTime)
        {
            if (IsExistInHotel(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            Procedure procedure = new Fitness();
            procedure.DoService(animalsInHotel[name], procedureTime);
            procedures.Add(procedure);
            string result = $"{name} had fitness procedure";
            return result;
        }

        public string Play(string name, int procedureTime)
        {
            if (IsExistInHotel(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            Procedure procedure = new Play();
            procedure.DoService(animalsInHotel[name], procedureTime);
            procedures.Add(procedure);
            string result = $"{name} was playing for {procedureTime} hours";
            return result;
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (IsExistInHotel(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            Procedure procedure = new DentalCare();
            procedure.DoService(animalsInHotel[name], procedureTime);
            procedures.Add(procedure);
            string result = $"{name} had dental care procedure";
            return result;
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (IsExistInHotel(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            Procedure procedure = new NailTrim();
            procedure.DoService(animalsInHotel[name], procedureTime);
            procedures.Add(procedure);
            string result = $"{name} had nail trim procedure";
            return result;
        }

        public string Adopt(string animalName, string owner)
        {
            if (!IsExistInHotel(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            
            animalsInHotel[animalName].IsAdopt = true;
            animalsInHotel[animalName].Owner = owner;
            //animalsInHotel.Remove(animalName);
            string result = "";
            if (animalsInHotel[animalName].IsChipped)
            {
                result = $"{owner} adopted animal without chip";
            }
            else
            {
                result = $"{owner} adopted animal with chip";
                
            }
            return result;
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Procedure procedure in procedures.Where(x => x.GetType().Name == type))
            {
                sb.AppendLine(procedure.History());
                
            }
            string forReturn = sb.ToString().TrimEnd();

            return forReturn;
        }
            
    }
}
