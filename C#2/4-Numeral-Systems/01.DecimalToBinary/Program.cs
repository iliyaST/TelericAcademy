using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void ToBinary(long number)
    {
        List<long> binary = new List<long>();

        while (number > 0)
        {
            binary.Add(number % 2);
            number = number / 2;
        }

        for (int i = binary.Count-1; i >= 0; i--)
        {
            Console.Write(binary[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        ToBinary(number);
    }
}

