
namespace ArmyOfCreatures.Extended.Specialties
{
    using ArmyOfCreatures.Logic.Specialties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArmyOfCreatures.Logic.Battles;
    using System.Globalization;
    public class AddAttackWhenSkip : Specialty
    {
        private int valueToAddToPermaAttack;
        public AddAttackWhenSkip(int valueToAdd)
        {
            if (valueToAdd < 1)
            {
                throw new ArgumentOutOfRangeException("Value to add must not be under 1 inclusive!");
            }

            if (valueToAdd > 10)
            {
                throw new ArgumentOutOfRangeException("Value to add must be below 10 inclusive!");
            }

            this.valueToAddToPermaAttack = valueToAdd;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            skipCreature.PermanentAttack += valueToAddToPermaAttack;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.valueToAddToPermaAttack);
        }
    }
}
