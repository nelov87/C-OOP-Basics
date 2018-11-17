using P08_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public int CodeNumber
        {
            get { return codeNumber; }
            private set { codeNumber = value; }
        }


        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCode Number: {this.CodeNumber}";
        }


    }
}
