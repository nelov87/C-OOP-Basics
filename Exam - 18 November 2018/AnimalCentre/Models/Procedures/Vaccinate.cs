using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        private const int removeEnergy = 8;

        public Vaccinate() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (base.CheckProcedureTime(animal, procedureTime))
            {
                animal.ProcedureTime -= procedureTime;
                animal.Energy -= removeEnergy;
                animal.IsVaccinated = true;
                base.procedureHistory.Add(animal);
            }
        }
    }
}
