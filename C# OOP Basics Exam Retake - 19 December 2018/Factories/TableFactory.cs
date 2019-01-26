using SoftUniRestaurant.Models.Tables;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class TableFactory
    {
        public ITable Create(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    ITable insideTable = new InsideTable(tableNumber, capacity);
                    return insideTable;

                case "Outside":
                    ITable outsideTable = new OutsideTable(tableNumber, capacity);
                    return outsideTable;

                default:
                    return null;
            }
        }
    }
}
