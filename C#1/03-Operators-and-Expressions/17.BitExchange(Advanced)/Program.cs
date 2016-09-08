using System;
/*
Problem 16.** Bit Exchange (Advanced)
Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
The first and the second sequence of bits may not overlap.
*/
class BitExchangeAdvanced
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine().PadLeft(32, '0'));
        long result = number;
        Console.WriteLine("Insert p:");
        int firstBit = int.Parse(Console.ReadLine());
        Console.WriteLine("Insert q:");
        int secondBit = int.Parse(Console.ReadLine());
        Console.WriteLine("Insert k:");
        int k = int.Parse(Console.ReadLine());
        int p, q;

        for (int i = 0; i < k; i++)
        {
            p = firstBit + i;
            q = secondBit + i;
            result = (number >> p) % 2 == 1 ? result | (1 << q) : result & ~(1 << q);
            result = (number >> q) % 2 == 1 ? result | (1 << p) : result & ~(1 << p);
        }

        Console.WriteLine(number);
        Console.WriteLine(result);
    }
}

