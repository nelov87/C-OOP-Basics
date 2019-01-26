using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        private const int removeEnergy = 6;
        private const int addHapines = 12;

        public Play() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (base.CheckProcedureTime(animal, procedureTime))
            {
                animal.ProcedureTime -= procedureTime;
                animal.Energy -= removeEnergy;
                animal.Happiness += addHapines;
                base.procedureHistory.Add(animal);
            }
        }
    }
}
