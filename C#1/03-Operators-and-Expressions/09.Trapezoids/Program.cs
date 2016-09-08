using System;
/*
Problem 9. Trapezoids
Write an expression that calculates trapezoid's area by given sides a and b and height h. 
*/
class Trapezoids
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        double Area = ((a + b) / 2) * h;
        Console.WriteLine("{0:0.0000000}", Area);

    }
}
