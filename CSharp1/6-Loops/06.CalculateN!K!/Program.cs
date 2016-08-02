using System;
using System.Numerics;
/*
Problem 6. Calculate N! / K!
Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
Use only one loop.
*/
class Calculate2
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger k = BigInteger.Parse(Console.ReadLine());
        BigInteger factoriel = 1;
        BigInteger secondFactoriel = 1;
        int counter = 1;
        BigInteger sum = 0;


        for (int i = 1; i <= n; i++)
        {
            if (counter > k)
            {
                secondFactoriel *= i;
            }
            if (counter <= n)
            {
                factoriel *= counter;
                counter++;
                secondFactoriel *= i;
            }
        }

        sum = secondFactoriel / factoriel;

        Console.WriteLine(sum);
    }
}

