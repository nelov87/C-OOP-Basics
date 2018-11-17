using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private const int initialWeigth = 10;

        public ArmorRepairKit() : base(initialWeigth)
        {

        }

        public override void AffectCharacter(Character character)
        {
            //TODO needs to be alive.The character’s armor restored up to the base armor value

            throw new NotImplementedException();
        }
    }
}
