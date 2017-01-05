
namespace Dealership.Models
{
    using System;
    using Dealership.Contracts;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using System.Text;

    public class Truck : Vehicle, ITruck
    {
        private int weightCapacity;
        private int wheels = (int)VehicleType.Truck;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price)
        {
            this.WeightCapacity = weightCapacity;
            base.Type = VehicleType.Truck;
        }

        public override int Wheels
        {
            get
            {
                return this.wheels;
            }
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Weight capacity must be between 1 and 100!");
                }

                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine(String.Format("Wheels: {0}", this.Wheels));
            sb.AppendLine(String.Format("Price: {0:C}", this.Price));
            sb.AppendLine(String.Format("WeightCapacity: {0}", this.WeightCapacity));

            return sb.ToString();
        }
    }
}
