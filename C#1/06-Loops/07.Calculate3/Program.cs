using System;
using System.Numerics;
/*
Problem 7. Calculate N! / (K! * (N-K)!)
In combinatorics, the number of ways to choose k different members out of a group of n 
different elements (also known as the number of combinations) is calculated by the following formula:
formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). 
Try to use only two loops.
*/
class Calculate3
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger factoriel = 1;
        BigInteger secondFact = 1;
        BigInteger thirdFact = 1;
        BigInteger sum = 0;

        for (int i = 1; i <= n; i++)
        {
            if (i <= n - k)
            {
                thirdFact *= i;
            }
            factoriel *= i;
        }
        for (int i = 1; i <= k; i++)
        {
            secondFact *= i;
        }

        sum = factoriel / (secondFact * thirdFact);
        Console.WriteLine(sum);
    }
}

