
namespace WarMachines.Machines
{
    using System;
    using WarMachines.Interfaces;
    using WarMachines.Common.Enum;
    using Common;
    using System.Text;

    public class Fighter : Machine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            base.HealthPoints = Constants.FighterInitialPoints;
            base.MachineType = MachineType.Fighter;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            if (this.StealthMode == true)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("- {0}", this.Name));
            sb.AppendLine(String.Format(" *Type: {0}", this.MachineType));
            sb.Append(base.ToString());

            if (StealthMode)
            {
                sb.Append(" *Stealth:  ON");
            }
            else
            {
                sb.Append(" *Stealth: OFF");
            }

            return sb.ToString();
        }
    }
}
