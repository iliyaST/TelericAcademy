
namespace Dealership.Models
{
    using System;
    using Dealership.Contracts;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using System.Text;

    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string category;
        private int wheels = (int)VehicleType.Motorcycle;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            this.Category = category;
            base.Type = VehicleType.Motorcycle;
        }

        public override int Wheels
        {
            get
            {
                return this.wheels;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Category cant be null or emty");
                }

                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException("Category must be between 3 and 10 characters long!");
                }

                this.category = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());

            sb.AppendLine(String.Format("Wheels: {0}", this.Wheels));
            sb.AppendLine(String.Format("Price: {0:C}", this.Price));
            sb.AppendLine(String.Format("Category: {0}", this.Category));

            return sb.ToString();
        }
    }
}
