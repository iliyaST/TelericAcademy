using System;
using System.Collections.Generic;

namespace Point3D
{
    // <summary>
    /// Represents sequence of points in 3D space.
    /// </summary>
    public class Path
    {
        /// <summary>
        /// Holds path points of the instance.
        /// </summary>
        public List<Point3DCoordinates> points = new List<Point3DCoordinates>();

        /// <summary>
        /// Add Element to the list of points
        /// </summary>
        /// <param name="somePoint"></param>
        public void  AddPoint(Point3DCoordinates somePoint)
        {
            points.Add(somePoint);
        }
        /// <summary>
        /// Remove Element from the list of points.
        /// </summary>
        /// <param name="index"></param>
        public void DeletePoint(int index)
        {
            points.Remove(points[index]);
        }
    }
}
