using System;
/*
Problem 11. Random Numbers in Given Range
Write a program that enters 3 integers n, min and max (min != max) and prints n random numbers in the range [min...max].
*/
class RandomNumbersInGivenRange
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int minValue = int.Parse(Console.ReadLine());
        int maxValue = int.Parse(Console.ReadLine());
        Random rand = new Random();

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", rand.Next(minValue, maxValue + 1));
        }
    }
}

