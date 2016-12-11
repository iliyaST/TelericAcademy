
namespace Point3D
{
    using System;

    class Point3DTest
    {
        static void Main()
        {
            //just for testing the classes and structures

            Path newPath = PathStorage.LoadFile();
            Point3DCoordinates point = new Point3DCoordinates(1, 2, 6);

            newPath.AddPoint(point);

            foreach (var item in newPath.points)
            {
                Console.WriteLine(item.ToString());
            }

            PathStorage.SaveFile(newPath);

            Point3DCoordinates first = new Point3DCoordinates(1, 2, 3);
            Point3DCoordinates second = new Point3DCoordinates(1, 5, 8);

            Console.WriteLine(Distance.DistanceBetweenTwoPoints(first, second));
        }
    }
}
