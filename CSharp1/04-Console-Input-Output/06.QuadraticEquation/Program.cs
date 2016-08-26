using System;
/*
Problem 6. Quadratic Equation
Write a program that reads the coefficients a, b and c of a quadratic equation 
ax2 + bx + c = 0 and solves it (prints its real roots).
*/
class QuadricEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double x1;
        double x2;
        double discriminant;

        discriminant = b * b - 4 * a * c;
        x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
        x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

        if (discriminant < 0)
        {
            Console.WriteLine("no real roots");
        }
        else
        {
            if (discriminant == 0)
            {
                Console.WriteLine("{0:0.00}", x1);
            }
            else
            {
                Console.WriteLine("{0:0.00}", x2);
                Console.WriteLine("{0:0.00}", x1);
            }
        }
    }
}

