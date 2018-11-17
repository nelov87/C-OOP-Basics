using P08_MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; set; }
    }
}
