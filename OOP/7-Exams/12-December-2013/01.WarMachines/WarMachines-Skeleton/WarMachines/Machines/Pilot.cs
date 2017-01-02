
namespace WarMachines.Machines
{
    using Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }


        // TODO: Implement all machine classes in this namespace - WarMachines.Machines
        /// <summary>
        /// Properties
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,"Pilot name cannot be null!");

                this.name = value;

            }
        }

        public void AddMachine(IMachine machine)
        {
            Validator.CheckIfNull(machine,"Null machine cannot be addet to pilot!");

            this.machines.Add(machine);
        }

        public string Report()
        {
            var sortedMachines = machines
                .OrderBy(mc => mc.HealthPoints)
                .ThenBy(mc => mc.Name);


            string machinesCount = "";

            if (this.machines.Count > 0)
            {
                machinesCount = this.machines.Count().ToString();
            }
            else
            {
                machinesCount = "no";
            }

            string plural = "";

            if (this.machines.Count == 1)
            {
                plural = "machine";
            }
            else
            {
                plural = "machines";
            }

            var result = new StringBuilder();

            result.AppendLine(string.Format("{0} - {1} {2}", this.Name, machinesCount, plural));

            foreach (var machine in sortedMachines)
            {
                result.AppendLine(machine.ToString());
            }

            return result.ToString();
        }
    }
}
