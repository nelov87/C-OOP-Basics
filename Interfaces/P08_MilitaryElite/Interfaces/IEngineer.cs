using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}
