using AnimalCentre.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.IO
{
    public class Reader : IReader
    {
        public Reader()
        {
        }

        
        public string ReadLine()
        {
            //string result = string.Empty;
            //result = Console.ReadLine();
            //return result;
            
            return Console.ReadLine();
        }
    }
}
