using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        private const int removeHapines = 7;

        public NailTrim() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (base.CheckProcedureTime(animal, procedureTime))
            {
                animal.ProcedureTime -= procedureTime;
                animal.Happiness -= removeHapines;
                base.procedureHistory.Add(animal);
            }
        }
    }
}
