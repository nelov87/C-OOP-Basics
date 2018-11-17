using System;
using System.Collections.Generic;
using System.Text;

namespace P06_BirthdayCelebrations
{
    public class Pet : IBurthable
    {
        public string Name { get; set; }
        public string BurthDate { get; set; }

        public Pet()
        {

        }
        public Pet(string name, string burthDate)
        {
            Name = name;
            BurthDate = burthDate;
        }
    }
}
