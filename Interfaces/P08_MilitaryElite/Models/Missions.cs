using P08_MilitaryElite.Enums;
using P08_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Models
{
    public class Missions : IMission
    {
        private string codeName;
        private State state;

        public Missions(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName
        {
            get => codeName;
            private set => codeName = value;
        }
        public State State
        {
            get => state;
            private set => state = value;
        }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
