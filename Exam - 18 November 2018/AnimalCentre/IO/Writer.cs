using AnimalCentre.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.IO
{
    public class Writer : IWriter
    {
        public Writer()
        {
        }

        public void Write(string str)
        {
            Console.Write(str);
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
