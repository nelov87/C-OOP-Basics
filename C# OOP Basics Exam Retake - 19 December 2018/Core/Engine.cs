using SoftUniRestaurant.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private RestaurantController restaurant;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.restaurant = new RestaurantController();
        }

        public void Run()
        {
            string input = reader.Read();

            while (input != "END")
            {
                string[] arguments = input.Split().ToArray();
                string command = arguments[0];
                string[] parameters = arguments.Skip(1).ToArray();
                string result = string.Empty;
                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            //{type} {name} {price}
                            string foodType = parameters[0];
                            string foodName = parameters[1];
                            decimal foodPrice = decimal.Parse(parameters[2]);
                            result = restaurant.AddFood(foodType, foodName, foodPrice);
                            writer.Write(result);
                            break;
                        case "AddDrink":
                            //{type} {name} {servingSize} {brand}
                            string drinkType = parameters[0];
                            string drinkName = parameters[1];
                            int drinkServingSize = int.Parse(parameters[2]);
                            string drinkBrand = parameters[3];
                            result = restaurant.AddDrink(drinkType, drinkName, drinkServingSize, drinkBrand);
                            writer.Write(result);
                            break;
                        case "AddTable":
                            //{type} {tableNumber} {capacity}
                            string tableType = parameters[0];
                            int tableNumber = int.Parse(parameters[1]);
                            int tableCapacity = int.Parse(parameters[2]);
                            result = restaurant.AddTable(tableType, tableNumber, tableCapacity);
                            writer.Write(result);
                            break;
                        case "ReserveTable":
                            //{numberOfPeople}
                            int numberOfPeople = int.Parse(parameters[0]);
                            result = restaurant.ReserveTable(numberOfPeople);
                            writer.Write(result);
                            break;
                        case "OrderFood":
                            // {tableNumber} {foodName}
                            int tableToOrder = int.Parse(parameters[0]);
                            string foodToOrder = parameters[1];
                            result = restaurant.OrderFood(tableToOrder, foodToOrder);
                            writer.Write(result);
                            break;
                        case "OrderDrink":
                            // {tableNumber} {drinkName} {drinkBrand}
                            tableToOrder = int.Parse(parameters[0]);
                            string drinkToOrder = parameters[1];
                            drinkBrand = parameters[2];
                            result = restaurant.OrderDrink(tableToOrder, drinkToOrder, drinkBrand);
                            writer.Write(result);
                            break;
                        case "LeaveTable":
                            // {tableNumber}
                            int tableToLeave = int.Parse(parameters[0]);
                            result = restaurant.LeaveTable(tableToLeave);
                            writer.Write(result);
                            break;
                        case "GetFreeTablesInfo":
                            result = restaurant.GetFreeTablesInfo();
                            
                            if (result.Length > 0)
                            {
                                writer.Write(result);
                            }
                            break;
                        case "GetOccupiedTablesInfo":
                            result = restaurant.GetOccupiedTablesInfo();
                            if (result.Length > 0)
                            {
                                writer.Write(result);
                            }
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    writer.Write(ae.Message);
                }
                catch (Exception e)
                {
                    writer.Write(e.Message);
                }

                input = reader.Read();
            }

            string sumary = restaurant.GetSummary();
            writer.Write(sumary);
        }
    }
}
