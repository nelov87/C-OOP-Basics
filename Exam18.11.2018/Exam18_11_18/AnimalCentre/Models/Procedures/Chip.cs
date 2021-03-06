﻿using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        //private List<Animal> procedurAnimalsList;

        public Chip()
        {
            
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            Animal curentAnimal = (Animal)animal;
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
            if (curentAnimal.ProcedureTime - procedureTime < 0)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            
                curentAnimal.Happiness -= 5;
                
                curentAnimal.ProcedureTime -= procedureTime;

            this.procedurAnimalsList.Add(curentAnimal);
            
        }

        public override string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}");
            foreach (Animal animal in ProcedureHistory)
            {
                sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }
            
            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
