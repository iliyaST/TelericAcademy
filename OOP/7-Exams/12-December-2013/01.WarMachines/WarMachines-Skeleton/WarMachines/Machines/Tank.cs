
using System;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank, IMachine
    {
        /// <summary>
        /// Field
        /// </summary>
        private const int InitialHealthPoints = 100;
        private const int AtackPointsChange = 40;
        private const int DefensePointsChange = 30;

        public Tank(string name, double attackPoints, double defensePoints) :
            base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !DefenseMode;
            if (DefenseMode)
            {
                this.AttackPoints -= AtackPointsChange;
                this.DefensePoints += DefensePointsChange;
            }
            else
            {
                this.AttackPoints += AtackPointsChange;
                this.DefensePoints -= DefensePointsChange;
            }
        }

        public override string ToString()
        {
            var baseString = base.ToString();

            var result = new StringBuilder();

            result.Append(baseString);

            result.Append(String.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));

            return result.ToString();
        }
    }
}
