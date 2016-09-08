using System;
/*
Problem 1. Exchange If Greater
Write an if-statement that takes two double variables a and b and exchanges their values if the first
one is greater than the second one. As a result print the values a and b, separated by a space.
*/
class ExchamgeIfGreater
{
    static void Main()
    {
        double firstValue = double.Parse(Console.ReadLine());
        double secondValue = double.Parse(Console.ReadLine());

        if (firstValue > secondValue)
        {
            double temp;
            temp = firstValue;
            firstValue = secondValue;
            secondValue = temp;
        }

        Console.WriteLine("{0} {1}", firstValue, secondValue);
    }
}

