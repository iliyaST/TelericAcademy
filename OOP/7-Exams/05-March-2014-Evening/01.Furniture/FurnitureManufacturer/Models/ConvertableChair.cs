
namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class ConvertableChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private const decimal ConvertedHeight = 0.10m;

        public ConvertableChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
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
            if (isConverted)
            {
                isConverted = false;
            }
            else
            {
                isConverted = true;
            }
        }

        public override decimal Height
        {
            get
            {
                if (isConverted)
                {
                    return ConvertedHeight;
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
    }
}
