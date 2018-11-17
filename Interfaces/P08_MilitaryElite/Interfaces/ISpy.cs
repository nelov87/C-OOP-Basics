using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
