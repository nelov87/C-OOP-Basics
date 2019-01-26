using System;
using System.Collections.Generic;
using System.Text;

namespace TestIReadOnly
{
    public class Service
    {
        public Service()
        {

        }

        public void DoService(Animal animal)
        {
            animal.Test = true;
        }
    }
}
