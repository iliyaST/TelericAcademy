
namespace WarMachines.Machines
{
    using Common;
    using Common.Enum;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Machine : IMachine
    {
        private string name;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public MachineType MachineType { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public double HealthPoints { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.ValidateString(value, nameof(Name));

                this.name = value;
            }
        }

        public IPilot Pilot { get; set; }

        public IList<string> Targets { get; }

        public void Attack(string target)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format(" *Health: {0}", this.HealthPoints));
            sb.AppendLine(String.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(String.Format(" *Defense: {0}", this.DefensePoints));

            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else
            {
                sb.AppendLine(String.Format(" *Targets: {0}", String.Join(", ", this.Targets)));
            }

            return sb.ToString();
        }
    }
}
