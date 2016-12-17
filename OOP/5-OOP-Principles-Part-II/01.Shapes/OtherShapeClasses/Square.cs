
using System;

namespace Shapes
{
    /// <summary>
    /// Represents a Square geometric figure
    /// </summary>
    public class Square : Shape
    {
        /// <summary>
        /// Initialize constructor with equaliy width and heigth
        /// </summary>
        /// <param name="width"></param>
        /// <param name="heigth"></param>
        public Square(double width)
            :base(width,width)
        {

        }

        /// <summary>
        /// Ovveride the Shapes class method Calculate surfice with equal width and heigth
        /// </summary>
        /// <param name="width"></param>
        /// <param name="heigth"></param>
        /// <returns></returns>
        public override double CalculateSurface()
        {
            double Surfice = width * 4;

            return Surfice;
        }
    }
}
