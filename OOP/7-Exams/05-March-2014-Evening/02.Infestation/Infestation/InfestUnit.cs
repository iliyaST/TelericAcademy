using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class InfestUnit : Unit
    {
        public InfestUnit(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            // return this != unit;
            if (this.Id != unit.Id && InfestationRequirements
                 .RequiredClassificationToInfest(unit.UnitClassification)
                 == this.UnitClassification)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Power)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
