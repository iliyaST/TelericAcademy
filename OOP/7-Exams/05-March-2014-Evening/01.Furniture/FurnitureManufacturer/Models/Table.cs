
namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;
    using System.Text;

    public class Table : Furniture, IFurniture, ITable
    {
        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area));

            return sb.ToString();
        }
    }
}
