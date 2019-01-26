using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestIReadOnly
{
    public class Hotel
    {
        private Dictionary<string, Animal> animals;

        public IReadOnlyDictionary<string, Animal> Animals
        {
            get
            {
                return new ReadOnlyDictionary<string, Animal>(this.animals);
            }
        }

        public Hotel()
        {
            this.animals = new Dictionary<string, Animal>();
            this.animals.Add("Pesho", new Animal("Pesho", 10));
            this.animals.Add("Gosho", new Animal("Gosho", 20));
        }

    }
}
