using System;
/*
Problem 10. Point Inside a Circle & Outside of a Rectangle
Write an expression that checks for given point (x, y) 
if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).
*/
class PointInsideACircleOutsideOfARectangle
{
    static void Main()
    {
        double coordinateXOfCircle = 1;
        double coordinateYOfCircle = 1;
        double radiusOfCircle = 1.5;
        double coordinateXOfRectangle = 1;
        double coordinateYOfRectangle = -1;
        double coordinateXOfPoint = double.Parse(Console.ReadLine());
        double coordinateYOfPoint = double.Parse(Console.ReadLine());

        bool isInCircle = (coordinateXOfPoint - coordinateXOfCircle) * (coordinateXOfPoint - coordinateXOfCircle) +
            (coordinateYOfPoint - coordinateYOfCircle) * (coordinateYOfPoint - coordinateYOfCircle) <= radiusOfCircle * radiusOfCircle;
        bool isInRectangle = ((coordinateXOfPoint >= -1 && coordinateXOfPoint <= 5) && (coordinateYOfPoint <= 1 && coordinateYOfPoint >= -1));
        if (isInCircle)
        {
            if (isInRectangle)
            {
                Console.WriteLine("inside circle inside rectangle");
            }
            else
            {
                Console.WriteLine("inside circle outside rectangle");
            }
        }
        else
        {
            if (isInRectangle)
            {
                Console.WriteLine("outside circle inside rectangle");
            }
            else
            {
                Console.WriteLine("outside circle outside rectangle");
            }
        }
    }
}

