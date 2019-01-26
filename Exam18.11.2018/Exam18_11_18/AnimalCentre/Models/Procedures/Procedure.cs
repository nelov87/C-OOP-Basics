using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<Animal> procedurAnimalsList;
        

        public IReadOnlyCollection<Animal> ProcedureHistory => procedurAnimalsList.AsReadOnly();

        public Procedure()
        {
            procedurAnimalsList = new List<Animal>();
            
        }


        public abstract void DoService(IAnimal animal, int procedureTime);
        public abstract string History();
        
            
    }
}
