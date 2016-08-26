using System;
/*
Problem 4. Rectangles
Write an expression that calculates rectangle’s perimeter and area by given width and height.
*/
class Rectangles
{
    static void Main()
    {
        Console.WriteLine("Enter weight:");
        double width = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter height:");
        double height = double.Parse(Console.ReadLine());


        double Perimeter = 2 * width + 2 * height;
        double Area = width * height;

        Console.WriteLine("{0:0.00} {1:0.00}", Area, Perimeter);
    }
}

