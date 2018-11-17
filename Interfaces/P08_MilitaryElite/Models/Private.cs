using P08_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public decimal Salary
        {
            get => salary;
            private set => salary = value;
        }

        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {this.Salary:f2}";
        }
    }
}
