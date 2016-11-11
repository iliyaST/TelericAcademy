using System;
using System.Collections.Generic;

class DecimalToHexadecimal
{
    static void ToHex(long decimalNumber)
    {
        List<string> hex = new List<string>();

        while (decimalNumber > 0)
        {
            if (decimalNumber % 16 < 10)
            {
                hex.Add((decimalNumber % 16).ToString());
            }
            else
            {
                switch (decimalNumber % 16)
                {
                    case 10: hex.Add("A"); break;
                    case 11: hex.Add("B"); break;
                    case 12: hex.Add("C"); break;
                    case 13: hex.Add("D"); break;
                    case 14: hex.Add("E"); break;
                    case 15: hex.Add("F"); break;
                }
            }
            decimalNumber = decimalNumber / 16;
        }

        for (int i = hex.Count-1; i>=0; i--)
        {
            Console.Write(hex[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());

        ToHex(decimalNumber);
    }
}

