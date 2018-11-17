using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    public interface ISoldier
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
