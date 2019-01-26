using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public NailTrim()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            Animal curentAnimal = (Animal)animal;
            
            if (curentAnimal.ProcedureTime - procedureTime < 0)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            curentAnimal.Happiness -= 7;
            curentAnimal.ProcedureTime -= procedureTime;
            this.procedurAnimalsList.Add(curentAnimal);
        }

        public override string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}");
            foreach (Animal animal in ProcedureHistory)
            {
                sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
