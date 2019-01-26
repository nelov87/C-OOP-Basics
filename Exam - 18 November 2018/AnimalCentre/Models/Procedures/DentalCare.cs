using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        private const int AddHApiness = 12;
        private const int AddEnergy = 10;

        public DentalCare() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            

            if (base.CheckProcedureTime(animal, procedureTime))
            {
                animal.ProcedureTime -= procedureTime;
                animal.Happiness += AddHApiness;
                animal.Energy += AddEnergy;
                base.procedureHistory.Add(animal);

            }
        }
    }
}
