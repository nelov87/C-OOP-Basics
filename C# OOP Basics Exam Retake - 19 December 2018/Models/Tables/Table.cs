using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private IList<IFood> FoodOrders;
        private IList<IDrink> DrinkOrders;

        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            this.FoodOrders = new List<IFood>();
            this.DrinkOrders = new List<IDrink>();
        }

        

        public int TableNumber
        {
            get
            {
                return this.tableNumber;
            }
            private set
            {
                this.tableNumber = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get
            {
                return this.pricePerPerson;
            }
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved
        {
            get
            {
                return this.isReserved;
            }
            set
            {
                this.isReserved = value;
            }
        }

        public decimal Price
        {
            get
            {
                return NumberOfPeople * PricePerPerson;
            }
            
        }

        private decimal GetPrice()
        {
            return NumberOfPeople * PricePerPerson;
        }

        public void Clear()
        {
            this.FoodOrders.Clear();
            this.DrinkOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            decimal bill = 0M;
            bill += FoodOrders.Sum(f => f.Price);
            bill += DrinkOrders.Sum(d => d.Price);
            bill += GetPrice();
            return bill;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            if (this.FoodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.FoodOrders.Count}");
                foreach ( var food in this.FoodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }

            if (this.DrinkOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.DrinkOrders.Count}");
                foreach (var drink in this.DrinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"Table: {TableNumber}")
        //        .AppendLine($"Type: {this.GetType().Name}");


        //    return sb.ToString().TrimEnd();
        //}
    }
}
