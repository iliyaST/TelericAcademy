
namespace Dealership.Models
{
    using System;
    using Dealership.Contracts;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using System.Text;

    public class Car : Vehicle, ICar
    {
        public const int MinSeats = 1;
        public const int MaxSeats = 10;
        private int seats;
        private int wheels = (int)VehicleType.Car;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price)
        {
            this.Seats = seats;
            base.Type = VehicleType.Car;
        }

        public override int Wheels
        {
            get
            {
                return this.wheels;
            }
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            protected set
            {
                Validator.ValidateDecimalRange(value
                    , MinSeats
                    , MaxSeats
                    , String.Format("Seats must be between {0} and {1}!"
                    , MinSeats, MaxSeats));

                this.seats = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());

            sb.AppendLine(String.Format("  Wheels: {0}", this.Wheels));
            sb.AppendLine(String.Format("  Price: ${0}", this.Price));
            sb.AppendLine(String.Format("  Seats: {0}", this.Seats));

            return sb.ToString();
        }
    }
}
