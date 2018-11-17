using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodShortage
{
    interface IBuyer
    {
        string Name { get; set; }
        int Food { get; set; }
        void BuyFood();
    }
}
