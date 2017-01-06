
namespace WarMachines.Machines
{
    using Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            machines = new List<IMachine>();
        }

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

        public void AddMachine(IMachine machine)
        {
            Validator.ValidateNull(machine);

            machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            if (this.machines.Count == 0)
            {
                sb.Append(this.Name + " - " + "no machines");
            }
            else
            {
                if (this.machines.Count == 1)
                {
                    sb.AppendLine(String.Format("{0} - {1} machine", this.Name, this.machines.Count));
                }
                else
                {
                    sb.AppendLine(String.Format("{0} - {1} machines", this.Name, this.machines.Count));
                }

                foreach (var machine in machines)
                {
                    sb.Append(machine.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
