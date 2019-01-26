using SoftUniRestaurant.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.IO
{
    public class Writer : IWriter
    {
        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
