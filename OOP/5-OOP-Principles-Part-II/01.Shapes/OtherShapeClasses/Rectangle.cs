using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes new instance of the Rectangle class specified by width and height.
        /// </summary>
        /// <param name="width">Rectangle's width.</param>
        /// <param name="height">Rectangle's height.</param>
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        /// <summary>
        /// Calculates a rectangles surface area.
        /// </summary>
        /// <returns>Rectangle's surface.</returns>
        public override double CalculateSurface()
        {
            double Surfice = width * height;

            return Surfice;
        }
    }
}
