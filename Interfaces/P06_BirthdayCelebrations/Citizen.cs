using System;
using System.Collections.Generic;
using System.Text;

namespace P06_BirthdayCelebrations
{
    public class Citizen : IBurthable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Age { get; set; }
        public string BurthDate { get; set; }

        public Citizen()
        {

        }

        public Citizen(string name, string age, string id, string burthDate)
        {
            Name = name;
            Id = id;
            Age = age;
            BurthDate = burthDate;
        }
    }
}
