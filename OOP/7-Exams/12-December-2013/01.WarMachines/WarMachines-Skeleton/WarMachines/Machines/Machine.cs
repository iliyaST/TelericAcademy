
namespace WarMachines.Machines
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string name;
        private IPilot pilot;
        private IList<string> targets;

        /// <summary>
        ///  Create machine
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attackPoints"></param>
        /// <param name="defensePoints"></param>
        protected Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }



        /// <summary>
        /// Properties no need to check DefensePoints or HeathPoints
        /// </summary>
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
                Validator.CheckIfStringIsNullOrEmpty(value, "Machine name cannot be null!");

                this.name = value;

            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                Validator.CheckIfNull(value, "Pilot cannot be null!");
                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return new List<string>(this.targets);
            }
        }

        public void Attack(string target)
        {
            Validator.CheckIfStringIsNullOrEmpty(target, "target cannot be null or empty");
            this.targets.Add(target);
        }

        public override string ToString()
        {
            //           -(machine name)
            //*Type: (“Tank”/”Fighter”)
            //*Health: (machine health points)
            //*Attack: (machine attack points)
            //*Defense: (machine defense points)
            //*Targets: (machine target names/”None” – comma separated)
            //*Defense: (“ON”/”OFF” – when applicable)
            //*Stealth: (“ON”/”OFF” – when applicable)
            var result = new StringBuilder();
            var targets = string.Empty;

            if (this.targets.Count > 0)
            {
                targets = String.Join(", ", this.targets);
            }
            else
            {
                targets = "None";
            }

            result.AppendLine(String.Format("- {0}", this.Name));
            result.AppendLine(String.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(String.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(String.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(String.Format(" *Defense: {0}", this.DefensePoints));
            result.AppendLine(String.Format(" *Targets: {0}", targets));

            return result.ToString().Trim();
        }
    }
}
