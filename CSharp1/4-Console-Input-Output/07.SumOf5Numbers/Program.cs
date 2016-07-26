using System;
/*
Problem 7. Sum of 5 Numbers
Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
*/
class SumOf5Numbers
{
    static void Main()
    {
        string numbers = Console.ReadLine();
        int a = Convert.ToInt32(numbers.Substring(0, 1));
        int b = Convert.ToInt32(numbers.Substring(2, 1));
        int c = Convert.ToInt32(numbers.Substring(4, 1));
        int d = Convert.ToInt32(numbers.Substring(6, 1));
        int e = Convert.ToInt32(numbers.Substring(8, 1));

        Console.WriteLine(a + b + c + d + e);
    }
}

