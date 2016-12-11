using System;

namespace Point3D
{
    public static class Distance
    {
       public static int DistanceBetweenTwoPoints(Point3DCoordinates firstPoint ,Point3DCoordinates secondPoint)
        {
            int xd = firstPoint.X - secondPoint.X;
            int yd = firstPoint.Y - secondPoint.Y;
            int zd = firstPoint.Z - secondPoint.Z;

            return (int)Math.Sqrt((double)(xd * xd + yd * yd + zd * zd));
        }
    }
}
