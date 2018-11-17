using System;
using System.Collections.Generic;
using System.Text;

namespace P06_BirthdayCelebrations
{
    public class Robot : IBurthable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string BurthDate { get; set; }

        public Robot()
        {

        }

        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
