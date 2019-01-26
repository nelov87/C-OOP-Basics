using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private int capacity;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            capacity = 10;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get
            {
                return new ReadOnlyDictionary<string, IAnimal>(this.animals);
            }
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.Capacity == 0)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            this.animals.Add(animal.Name, animal);
            this.capacity--;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = animals[animalName];
            animal.Owner = owner;
            animal.IsAdopt = true;
            animals.Remove(animalName);
            this.capacity++;
        }

    }
}
