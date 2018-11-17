using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int initialWeigth = 5;

        public HealthPotion() : base(initialWeigth)
        {

        }

        public override void AffectCharacter(Character character)
        {
            // TODO Implement Method
            EnsureIsAlive(character);
            throw new NotImplementedException();
        }
    }
}
