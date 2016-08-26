using System;
using System.Numerics;
/*
Problem 18.* Trailing Zeroes in N!
Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
Your program should work well for very big numbers, e.g. n=100000.
*/
class TrailingZerosInNFact
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int countA = 5;
        int countB = 0;

        while (n / countA >= 1)
        {
            countB += n / countA;
            countA *= 5;
        }
        Console.WriteLine(countB);

    }

}


