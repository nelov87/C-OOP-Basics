using P08_MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; set; }
    }
}
