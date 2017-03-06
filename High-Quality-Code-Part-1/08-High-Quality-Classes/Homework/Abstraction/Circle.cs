namespace Abstraction
{
    using System;

    public class Circle : Figure
    {        
        public Circle(double radius)
            : base(radius, radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius cannot be empty or less than zero.");
            }

            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
