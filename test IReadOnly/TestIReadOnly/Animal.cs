using System;
using System.Collections.Generic;
using System.Text;

namespace TestIReadOnly
{
    public class Animal
    {
        private string name;
        private int age;
        private bool test;

        public bool Test
        {
            get { return test; }
            set { test = value; }
        }


        public int Age { get; set; }
        public string Name { get; set; }

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Test = false;
        }
    }
}
