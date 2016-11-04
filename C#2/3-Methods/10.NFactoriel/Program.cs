using System;
using System.Numerics;

class NFactoriel
{
    static BigInteger nFactoriel(BigInteger number)
    {
        BigInteger sum = 1;

        for (BigInteger i = 1; i <= number; i++)
        {
            sum *= i;
        }

        return sum;
    }

    static void Print(BigInteger sum)
    {
        Console.WriteLine(sum);
    }

    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());

        BigInteger factoriel = nFactoriel(number);

        Print(factoriel);
    }
}

