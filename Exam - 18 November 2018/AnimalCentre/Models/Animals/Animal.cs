using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner = "Centre";
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name
        {
            get{ return this.name; }
            set{ this.name = value; }
        }
        public int Happiness
        {
            get { return this.happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }
        public int Energy
        {
            get { return this.energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }
        public int ProcedureTime
        {
            get { return this.procedureTime; }
            set
            {
                this.procedureTime = value;
            }
        }
        public string Owner {
            get { return this.owner; }
            set { this.owner = value; }
        }
        public bool IsAdopt
        {
            get { return this.isAdopt; }
            set {this.isAdopt = value;
            }
        }
        public bool IsChipped
        {
            get { return this.isChipped; }
            set { this.isChipped = value; }
        }
        public bool IsVaccinated
        {
            get { return this.isVaccinated; }
            set { this.isVaccinated = value; }
        }

        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";
        }
    }
}
