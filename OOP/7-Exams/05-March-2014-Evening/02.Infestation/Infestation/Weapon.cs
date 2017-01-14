
using System;

namespace Infestation
{
    public class Weapon : Supplement
    {
        private bool hasEffect = false;
        const int weaponPower = 10;
        const int weaponAggression = 3;
        const int weaponHealth = 0;

        public Weapon()
            : base(weaponHealth, weaponPower, weaponAggression)
        {

        }

        public override int AggressionEffect
        {
            get
            {
                if (!hasEffect)
                {
                    return 0;
                }
                else
                {
                    return base.AggressionEffect;
                }
            }
        }

        public override int PowerEffect
        {
            get
            {
                if (hasEffect)
                {
                    return base.PowerEffect;                }
                else
                {
                    return 0;
                }
            }
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.hasEffect = true;
            }
        }

    }
}
