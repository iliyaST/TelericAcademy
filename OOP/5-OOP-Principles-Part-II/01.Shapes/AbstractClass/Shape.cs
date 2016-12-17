
namespace Shapes
{
    /// <summary>
    /// Abstract representation of a shape figure.
    /// </summary>
    public abstract class Shape
    {
        protected double width;
        protected double height;

        /// <summary>
        /// Initializes width and height of a shape. Used only by derived classes.
        /// </summary>
        /// <param name="width">Width of the shape.</param>
        /// <param name="height">Height of the shape.</param>
        protected Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Enforces all derived shape classes to have method for calculating it's surface.
        /// </summary>
        /// <returns>Shape surface.</returns>
        public abstract double CalculateSurface();
    }
}