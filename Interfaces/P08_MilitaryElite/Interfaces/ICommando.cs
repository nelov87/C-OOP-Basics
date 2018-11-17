using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; set; }
    }
}
