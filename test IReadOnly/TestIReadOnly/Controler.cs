using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TestIReadOnly
{
    public class Controler
    {
        private Hotel hotel;

        public Controler()
        {
            this.hotel = new Hotel();
            
        }

        public void TestMethod()
        {
            Service service = new Service();
            IReadOnlyDictionary<string, Animal> Animals = this.hotel.Animals;
            Animal animal = Animals["Pesho"];
            service.DoService(animal);
            Console.WriteLine(hotel.Animals.FirstOrDefault(a => a.Value.Name == "Pesho"));
        }


    }
}
