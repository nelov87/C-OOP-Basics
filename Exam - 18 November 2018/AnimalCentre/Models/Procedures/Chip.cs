using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    class Chip : Procedure
    {
        private const int removeHapines = 5;

        public Chip() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            if (base.CheckProcedureTime(animal, procedureTime))
            {
                animal.ProcedureTime -= procedureTime;
                animal.Happiness -= removeHapines;
                animal.IsChipped = true;
                base.procedureHistory.Add(animal);
            }
            
        }
    }
}
