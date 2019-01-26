using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.IO.Contracts
{
    public class Reader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
