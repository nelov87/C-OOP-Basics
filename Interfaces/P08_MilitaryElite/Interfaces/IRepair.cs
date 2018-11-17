using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
