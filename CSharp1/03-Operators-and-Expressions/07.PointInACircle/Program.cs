using System;
/*
Problem 7. Point in a Circle
Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
*/
class PointInACircle
{
    static void Main()
    {
        double coordinateXOfCircle = 0;
        double coordinateYOfCircle = 0;
        double radiusOfCircle = 2;
        double coordinateXOfDote = double.Parse(Console.ReadLine());
        double coordinateYOfDote = double.Parse(Console.ReadLine());

        bool isInOrOut = (coordinateXOfDote - coordinateXOfCircle) * (coordinateXOfDote - coordinateXOfCircle)
            + (coordinateYOfDote - coordinateYOfCircle) * (coordinateYOfDote - coordinateYOfCircle) <= Math.Pow(radiusOfCircle, 2);
        string result = isInOrOut.ToString();
        double position = Math.Sqrt((coordinateXOfDote - coordinateXOfCircle) * (coordinateXOfDote - coordinateXOfCircle) + (coordinateYOfDote - coordinateYOfCircle) * (coordinateYOfDote - coordinateYOfCircle));
        if (result == "True")
        {
            Console.WriteLine("yes {0:0.00}",position);
        }
        else
        {
            Console.WriteLine("no {0:0.00}",position);
        }
    }
}

