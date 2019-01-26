using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private IHotel hotel;
        private IDictionary<string, IProcedure> procedures;
        private IDictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, IProcedure>();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
            InitializateProcedurs();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Cat":
                    if (!IsRegistered(name))
                    {
                        IAnimal animal = new Cat(name, energy, happiness, procedureTime);
                        this.hotel.Accommodate(animal);
                        
                    }
                    return $"Animal {name} registered successfully";
                    
                case "Dog":
                    if (!IsRegistered(name))
                    {
                        IAnimal animal = new Dog(name, energy, happiness, procedureTime);
                        this.hotel.Accommodate(animal);
                        
                    }
                    return $"Animal {name} registered successfully";
                    
                case "Lion":
                    if (!IsRegistered(name))
                    {
                        IAnimal animal = new Lion(name, energy, happiness, procedureTime);
                        this.hotel.Accommodate(animal);
                        
                    }
                    return $"Animal {name} registered successfully";
                    
                case "Pig":
                    if (!IsRegistered(name))
                    {
                        IAnimal animal = new Pig(name, energy, happiness, procedureTime);
                        this.hotel.Accommodate(animal);
                        
                    }
                    return $"Animal {name} registered successfully";
                    
                default:
                    return null;
            }
        }

        public string Chip(string name, int procedureTime)
        {
            //IsRegistered(name);
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["Chip"].DoService(animal, procedureTime);
            return $"{animal.Name} had chip procedure";

        }

        public string Vaccinate(string name, int procedureTime)
        {
            
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["Vaccinate"].DoService(animal, procedureTime);
            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["Fitness"].DoService(animal, procedureTime);
            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["Play"].DoService(animal, procedureTime);
            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["DentalCare"].DoService(animal, procedureTime);
            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["NailTrim"].DoService(animal, procedureTime);
            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!this.hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animal = this.hotel.Animals[animalName] ?? null;

            this.hotel.Adopt(animalName, owner);

            if (!adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals.Add(owner, new List<string>());
                this.adoptedAnimals[owner].Add(animalName);
            }
            else
            {
                this.adoptedAnimals[owner].Add(animalName);
            }

            return animal.IsChipped ? $"{owner} adopted animal with chip" : $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            string output = string.Empty;
            switch (type)
            {
                case "Chip":
                    output = procedures["Chip"].History();
                    break;
                case "DentalCare":
                    output = procedures["DentalCare"].History();
                    break;
                case "Play":
                    output = procedures["Play"].History();
                    break;
                case "Vaccinate":
                    output = procedures["Vaccinate"].History();
                    break;
                case "Fitness":
                    output = procedures["Fitness"].History();
                    break;
                case "NailTrim":
                    output = procedures["NailTrim"].History();
                    break;
            }
            return output;
        }

        public bool IsRegistered(string name)
        {
            if (this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} already exist");
            }
            else
            {
                return false;
            }
        }


        private void InitializateProcedurs()
        {
            this.procedures.Add("Chip", new Chip());
            this.procedures.Add("DentalCare", new DentalCare());
            this.procedures.Add("Fitness", new Fitness());
            this.procedures.Add("NailTrim", new NailTrim());
            this.procedures.Add("Play", new Play());
            this.procedures.Add("Vaccinate", new Vaccinate());
        }

        public IReadOnlyDictionary<string, List<string>> AdoptedAnimls
        {
            get
            {
                return new Dictionary<string, List<string>>(this.adoptedAnimals);
            }
        }
    }
}
