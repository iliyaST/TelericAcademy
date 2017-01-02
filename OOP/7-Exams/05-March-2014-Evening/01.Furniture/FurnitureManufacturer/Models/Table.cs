
namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal height;
        private string materialType;
        private string model;
        private decimal price;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
        {
            this.Model = model;
            this.MaterialType = materialType;
            this.Price = price;
            this.Height = height;
            this.Length = length;
            this.Width = width;
        }

        public decimal Area
        {
            get
            {
                return Length * Width;
            }
        }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Length: {0}, Width: {1}, Area: {2}",
                this.Length, this.Width, this.Area);
        }
    }
}
