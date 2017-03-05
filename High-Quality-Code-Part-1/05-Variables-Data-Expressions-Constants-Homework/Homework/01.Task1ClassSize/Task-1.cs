namespace Task_1_Class_Size
{
    using System;

    /// <summary>
    /// Size of figure depending on width and heigth
    /// </summary>
    public class Size
    {
        /// <summary>
        /// Initialize a new instance of figure
        /// </summary>
        /// <param name="width">Width of the figure</param>
        /// <param name="height">Height of the figure</param>
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets and sets the width of the figure
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets and sets the heigth of the figure
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Calculates size of the figure after it has been rotated
        /// </summary>
        /// <param name="figureSize">currentSize of the figure</param>
        /// <param name="angleOfRotation">angle that the figure is going to be rotatet around</param>
        /// <returns>returns a new istance of size with the rotated width and heigth</returns>
        public static Size GetRotatedSize(Size figureSize, double angleOfRotation)
        {
            double absoluteCosAngle = Math.Abs(Math.Cos(angleOfRotation));
            double absoluteSinAngle = Math.Abs(Math.Sin(angleOfRotation));

            double rotatedWidth = absoluteCosAngle * (figureSize.Width + figureSize.Height);

            double rotatedHeight = absoluteSinAngle * (figureSize.Width + figureSize.Height);
 
            var newSize = new Size(rotatedWidth, rotatedHeight);

            return newSize;
        }
    }
}