using System;
/*
Problem 3. Circle Perimeter and Area
Write a program that reads the radius r of a circle and prints its 
perimeter and area formatted with 2 digits after the decimal point. 
*/
class CirclePerAndArea
{
    static void Main()
    {
        double radius = double.Parse(Console.ReadLine());
        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * radius * radius;

        Console.WriteLine("{0:0.00} {1:0.00}", perimeter, area);
    }
}

