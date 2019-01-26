namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Factories;
    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private IList<IFood> menu;
        private IList<IDrink> drinks;
        private IList<ITable> tables;
        private decimal income = 0;
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }

        //public IReadOnlyList<IFood> Menu
        //{
        //    get
        //    {
        //        return new ReadOnlyCollection<IFood>(this.menu);
        //    }
        //}
        //public IReadOnlyList<IDrink> Drinks
        //{
        //    get
        //    {
        //        return new ReadOnlyCollection<IDrink>(this.drinks);
        //    }
        //}
        //public IReadOnlyList<ITable> Tables
        //{
        //    get
        //    {
        //        return new ReadOnlyCollection<ITable>(this.tables);
        //    }
        //}

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = foodFactory.Create(type, name, price);
            this.menu.Add(food);
            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
           
            IDrink drink = drinkFactory.Create(type, name, servingSize, brand);

            this.drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = tableFactory.Create(type, tableNumber, capacity);
            this.tables.Add(table);
            return $"Added table number {tableNumber} in the restaurant";

        }

        public string ReserveTable(int numberOfPeople)
        {


            ITable[] freeTables = tables.Where(t => t.IsReserved == false && t.Capacity >= numberOfPeople).ToArray();

            foreach (ITable table in freeTables)
            {

                tables.FirstOrDefault(t => t.TableNumber == table.TableNumber).Reserve(numberOfPeople);

                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";

            }
            return $"No available table for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!this.tables.Any(t => t.TableNumber == tableNumber) )
            {
                return $"Could not find table with {tableNumber}";
            }
            if (!this.menu.Any(f => f.Name == foodName))
            {
                return $"No {foodName} in the menu";
            }

            tables.FirstOrDefault(t => t.TableNumber == tableNumber).OrderFood(menu.FirstOrDefault(f => f.Name == foodName));
            
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!this.tables.Any(t => t.TableNumber == tableNumber))
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            //drink = drink ?? null;
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            
            tables.FirstOrDefault(t => t.TableNumber == tableNumber).OrderDrink(this.drinks.FirstOrDefault(d => d.Name == drinkName));
            
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            if (!this.tables.Any(t => t.TableNumber == tableNumber))
            {
                return $"Could not find table with {tableNumber}";
            }

            decimal bill = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber).GetBill();
            this.income += bill;
            this.tables.FirstOrDefault(t => t.TableNumber == tableNumber).Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {bill:f2}");
            return sb.ToString().TrimEnd();
            //return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}"; // DOES NOT WORK IN DJUDGE FOR SOME REASON!!!!!!!!!!!!!!!!!!!!
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ITable table in tables.Where(t => t.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ITable table in tables.Where(t => t.IsReserved == true))
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.income:f2}lv";
        }
    }
}
