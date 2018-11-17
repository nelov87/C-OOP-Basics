using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    public class Citizen : IIdentifaiable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Age { get; set; }


        public Citizen()
        {

        }

        public Citizen(string name, string age, string id)
        {
            Name = name;
            Id = id;
            Age = age;
        }
    }
}
