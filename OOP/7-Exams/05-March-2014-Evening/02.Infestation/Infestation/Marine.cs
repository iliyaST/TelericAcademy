
using System.Collections.Generic;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id)
        : base(id)
        {
            this.AddSupplement(new WeaponarySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Power < optimalAttackableUnit.Power)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
