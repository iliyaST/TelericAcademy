
using System;
using FurnitureManufacturer.Interfaces;

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
    }
}
