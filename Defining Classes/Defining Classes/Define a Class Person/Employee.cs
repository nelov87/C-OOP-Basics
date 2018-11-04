using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string department;
        private string position;
        private string email;
        private int age;

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

        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
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

        

        

        public Employee(string name, decimal salary, string position, string department, string email, int age)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = email;
            Age = age;

        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{this.Name} ");
            builder.Append($"{this.Salary:F2} ");
            builder.Append($"{(this.Email == null ? "n/a" : this.Email)} ");
            builder.Append($"{(this.Age == null ? -1 : this.Age)}");

            return builder.ToString();
        }

    }
}
