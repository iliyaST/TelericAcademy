
using System;
using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {
        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", 
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs));

            return sb.ToString();
        }
    }
}
