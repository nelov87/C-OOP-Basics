using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.IO.Contracts
{
    public interface IWriter
    {
        void Write(string str);
        void WriteLine(string str);
        
    }
}
