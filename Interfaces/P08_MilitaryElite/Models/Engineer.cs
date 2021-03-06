﻿using System;
using System.Collections.Generic;
using System.Text;
using P08_MilitaryElite.Enums;
using P08_MilitaryElite.Interfaces;

namespace P08_MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {this.Corps}\nRepairs:{(this.Repairs.Count == 0 ? "" : "\n  ")}{string.Join("\n  ", this.Repairs)}";
        }
    }
}
