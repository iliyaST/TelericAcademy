
namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;
    using Common;

    public class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        public Furniture(string model,string material,decimal price,decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.Height = height;
            this.Material = material;
        }

        public virtual decimal Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be less or equal to 0.00 m!");
                }

                this.height = value;
            }
        }

        public string Material { get; set; }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                Validator.StringIsNullOrEmpty(value, String.Format(Constants.StringCannotBeNullOrEmpty,
                    nameof(Model)));

                if (value.Length < 3)
                {
                    throw new ArgumentException(String.Format(Constants.StringLength,
                     nameof(Model),Constants.ModelMinLengthName));
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
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to $0.00!");
                }

                this.price = value;
            }
        }
    }
}
