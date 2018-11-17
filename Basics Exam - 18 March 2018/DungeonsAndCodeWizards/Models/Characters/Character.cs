using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;

        public double BaseHealth
        {
            get { return baseHealth; }
            set { baseHealth = value; }
        }


        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                else
                {
                    name = value;
                }
            }
        }

    }
}
    //• Name – a string (cannot be null or whitespace).
    //    ◦ Throw an ArgumentException with the message “Name cannot be null or whitespace!”
    //• BaseHealth – a floating-point number
    //• Health – a floating-point number(current health).
    //    ◦ Health maxes out at BaseHealth and mins out at 0. 
    //• BaseArmor – a floating-point number
    //• Armor – a floating-point number(current armor)
    //    ◦ Armor maxes out at BaseArmor and mins out at 0.
    //• AbilityPoints – a floating-point number
    //• Bag – a parameter of type Bag
    //• Faction – a constant value with 2 possible values: CSharp and Java
    //• IsAlive – boolean value(default value: True)
    //• RestHealMultiplier – a floating-point number(default: 0.2), could be overriden