using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int initialWeigth = 5;

        public PoisonPotion() : base(initialWeigth)
        {

        }

        public override void AffectCharacter(Character character)
        {
            // TODO The character’s health gets decreased by 20 points. If the character’s health drops to zero, the character dies (IsAlive  false).
            throw new NotImplementedException();
        }
    }
}
