using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public string DateOne { get; set; }
        public string DateTwo { get; set; }
        public int Difrence { get; set; }

        public DateModifier(string dateOne, string dateTwo)
        {
            this.DateOne = dateOne;
            this.DateTwo = dateTwo;

            Difrence = CalculateDinrence();
            
            
        }

        public int ReturnDifrence()
        {
            return this.Difrence;
        }

        private int CalculateDinrence()
        {
            DateTime first = DateTime.Parse(DateOne,System.Globalization.CultureInfo.InvariantCulture);
            DateTime second = DateTime.Parse(DateTwo,System.Globalization.CultureInfo.InvariantCulture);

            int difrence = int.Parse((first - second).Days.ToString());
            return difrence;
        }

    }
}
