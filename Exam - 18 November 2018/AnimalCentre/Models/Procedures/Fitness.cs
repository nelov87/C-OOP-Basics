using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        private const int AddEnergy = 10;
        private const int RemoveHapines = 3;

        public Fitness() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (base.CheckProcedureTime(animal, procedureTime))
            {
                animal.ProcedureTime -= procedureTime;
                animal.Energy += AddEnergy;
                animal.Happiness -= RemoveHapines;
                base.procedureHistory.Add(animal);
            }
        }
    }
}
