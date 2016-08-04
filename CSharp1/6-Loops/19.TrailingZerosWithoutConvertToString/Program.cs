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
        BigInteger fact = 1;
        int zeroCounter = 0;

        //find the factoriel
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }

        while (fact % 10 == 0)
        {
            fact /= 10;
            zeroCounter++;
        }
        Console.WriteLine(zeroCounter);
        Console.WriteLine("Quick way: {0} / 5 = {1}. {0}! has {1} trailing zeros.", n, n / 5);

    }
}

