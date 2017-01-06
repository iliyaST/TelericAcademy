
namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using Common.Enums;
    using Dealership.Contracts;
    using System.Text;

    public class Vehicle : IVehicle, ICommentable
    {
        private string model;
        private decimal price;
        private int wheels;
        private string make;
        private VehicleType type;

        public Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Comments = new List<IComment>();


            //this.Wheels = wheels;
        }


        public IList<IComment> Comments { get; }

        public string Make
        {
            get
            {
                return this.make;
            }
            protected set
            {
                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentException("Make must be between 2 and 15 characters long!");
                }

                this.make = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            protected set
            {
                this.type = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be empty!");
                }

                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Model must be between 1 and 15 characters long!");
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value < 0 || value > 1000000.0m)
                {
                    throw new ArgumentException("Price must be between 0.0 and 1000000.0!");
                }
                this.price = value;
            }
        }

        public virtual int Wheels
        {
            get
            {
                return this.wheels;
            }
            protected set
            {
                if (wheels < 2 || wheels > 10)
                {
                    throw new ArgumentException("Wheels must be between 2 and 10");
                }

                this.wheels = value;
            }
        }

        public override string ToString()
        {
            //Model: Z
            //Wheels: 2
            //Price: $9999
            //Category: Naked
            //  --COMMENTS--
            //  ----------
            //  Unikalen motor pichove
            //    User: pesho
            //  ----------
            //  ----------
            //  E toa go znam, brato. Padal e mai:)
            //    User: gosho
            //  ----------
            //  --COMMENTS--
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("  Make: {0}", this.Make));
            sb.AppendLine(String.Format("  Model: {0}", this.Model));

            return sb.ToString();
        }
    }
}
