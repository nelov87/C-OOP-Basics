using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private int age;
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public Person( )
        {
            this.age = 1;
            this.name = "No name";
        }
        public Person(string name)
        {
            this.name = name;
        }
        public Person(int age)
        {
            this.age = age;
            this.name = "No name";
        }

        public Person(string name, int age) : this(name)
        {
            this.age = age;
        }
        
    }
}
