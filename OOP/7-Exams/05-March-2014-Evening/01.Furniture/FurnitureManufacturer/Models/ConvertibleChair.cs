
namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;
    using System.Text;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private const decimal InitialConvertedHeigth = 0.10m;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            this.isConverted = !this.isConverted;
        }

        public override decimal Height
        {
            get
            {
                if (IsConverted)
                {
                    return InitialConvertedHeigth;
                }
                else
                {
                    return base.Height;
                }
            }

            set
            {
                base.Height = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal"));

            return sb.ToString();
        }
    }
}
