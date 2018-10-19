using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> FamilyList { get; set; }
        public Family()
        {
            FamilyList = new List<Person>();
        }

        public void AddMember(Person member)
        {

            FamilyList.Add(member);
        }

        public Person GetOldestMember()
        {
            
            return this.FamilyList.OrderByDescending( p => p.Age).First();
        }

    }
}
