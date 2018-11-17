using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private int capacity;
        private List<Item> items;
        private const int defoultCapacity = 100;

        protected Bag()
        {
            this.Capacity = defoultCapacity;
            this.items = new List<Item>();
        }

        protected Bag(int capacity) : this()
        {
            this.Capacity = capacity;
        }


        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public IReadOnlyCollection<Item> Items
        {
            get { return items.AsReadOnly(); }
            
        }

        public int Load
        {
            get { return items.Sum(i => i.Weight); }

        }


        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            else
            {
                items.Add(item);
            }
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new InvalidOperationException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);
            return item;
        }
    }
}
