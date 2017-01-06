
namespace WarMachines.Machines
{
    using System;
    using WarMachines.Interfaces;
    using WarMachines.Common.Enum;
    using Common;
    using System.Text;

    public class Tank : Machine, ITank
    {

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints - Constants.InitalAttackPointsChange
                  , defensePoints + Constants.InitialDefensePointsChange)
        {
            base.HealthPoints = Constants.TankInitialPoints;
            base.MachineType = MachineType.Tank;
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !DefenseMode;

            if (DefenseMode)
            {
                this.AttackPoints -= Constants.InitalAttackPointsChange;
                this.DefensePoints += Constants.InitialDefensePointsChange;
            }
            else
            {
                this.AttackPoints += Constants.InitalAttackPointsChange;
                this.DefensePoints -= Constants.InitialDefensePointsChange;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("- {0}", this.Name));
            sb.AppendLine(String.Format(" *Type: {0}", this.MachineType));
            sb.Append(base.ToString());

            if (DefenseMode)
            {
                sb.Append(" *Defense:  ON");
            }
            else
            {
                sb.Append(" *Defense:  OFF");
            }

            return sb.ToString();
        }
    }
}
