using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        private int weight;
        

        public int Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        public Item( int weight)
        {
            this.Weight = weight;
        }

        public abstract void AffectCharacter(Character character);
            

        protected void EnsureIsAlive(Character character)
        {
            if (character.IsAlive())
            {
                // TODO Add Exeption

            }
        }

    }
}
