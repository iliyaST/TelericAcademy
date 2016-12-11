using System;

namespace Point3D
{
    public struct Point3DCoordinates
    {
        /// <summary>
        /// The begining of the coordinate system.
        /// </summary>
        private static readonly Point3DCoordinates CoordinateSystemStart = new Point3DCoordinates(0, 0, 0);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3DCoordinates(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Properties
        /// </summary>
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Point3DCoordinates CSystemStart
        {
            get
            {
                return this.CSystemStart;
            }
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>Coordinates of Point</returns>
        public override string ToString()
        {
            return String.Format("(X: {0}, Y: {1}, Z: {2})", this.X, this.Y, this.Z);
        }
    }
}


