using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        private const int initialCapacity = 10;
        private Dictionary<string, IAnimal> animalsInHotel;
        
        private int capacit;

        public Hotel()
        {
            this.Capacit = initialCapacity;
        }

        public int Capacit
        {
            get { return capacit; }
            set { capacit = value; }
        }


        public IReadOnlyCollection<IAnimal> AnimalsInHotel
        {
            get
            {
                IReadOnlyCollection<IAnimal> animals = animalsInHotel.Values.ToArray();
                return animals;
            }
            
        }


        

        public void Accommodate(IAnimal animal)
        {
            if (AnimalsInHotel.Count >= 10)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (this.animalsInHotel.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animalsInHotel.Add(animal.Name, animal);

        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animalsInHotel.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            ((Animal)animalsInHotel[animalName]).Owner = owner;
            ((Animal)animalsInHotel[animalName]).IsAdopt = true;
        }
    }
}
