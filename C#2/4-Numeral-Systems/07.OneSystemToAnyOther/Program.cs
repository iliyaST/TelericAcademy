using System;
using System.Collections.Generic;
using System.Numerics;

class OneSystemToAnyOther
{
    static BigInteger MathPow(BigInteger anyBase, long pow)
    {
        BigInteger power = 1;

        for (int i = 0; i < pow; i++)
        {
            power *= anyBase;
        }

        if (pow == 0)
        {
            return 1;
        }
        else
        {
            anyBase = power;
            return anyBase;
        }
    }

    static BigInteger toDecimal(string numberInAnyBase, int anyBase)
    {
        BigInteger decimalNumber = 0;
        long len = numberInAnyBase.Length;
        long symbol;

        for (int i = 0; i < len; i++)
        {
            if (numberInAnyBase[i] != '0')
            {
                if (long.TryParse(numberInAnyBase[i].ToString(), out symbol))
                {
                    decimalNumber += symbol * MathPow(anyBase, len - 1 - i);
                }
                else
                {
                    switch (numberInAnyBase[i])
                    {
                        case 'A': symbol = 10; break;
                        case 'B': symbol = 11; break;
                        case 'C': symbol = 12; break;
                        case 'D': symbol = 13; break;
                        case 'E': symbol = 14; break;
                        case 'F': symbol = 15; break;
                    }

                    decimalNumber += symbol * MathPow(anyBase, len - 1 - i);
                }
            }
        }

        return decimalNumber;
    }

    static void ConvertToAnyOtherBase(BigInteger decimalNumber, int baseToConvertTo)
    {
        List<string> hex = new List<string>();

        while (decimalNumber > 0)
        {
            if (decimalNumber % baseToConvertTo < 10)
            {
                hex.Add((decimalNumber % baseToConvertTo).ToString());
            }
            else
            {
                if (decimalNumber % baseToConvertTo == 10)
                {
                    hex.Add("A");
                }
                else if (decimalNumber % baseToConvertTo == 11)
                {
                    hex.Add("B");
                }
                else if (decimalNumber % baseToConvertTo == 12)
                {
                    hex.Add("C");
                }
                else if (decimalNumber % baseToConvertTo == 13)
                {
                    hex.Add("D");
                }
                else if (decimalNumber % baseToConvertTo == 14)
                {
                    hex.Add("E");
                }
                else if (decimalNumber % baseToConvertTo == 15)
                {
                    hex.Add("F");
                }
            }
            decimalNumber = decimalNumber / baseToConvertTo;
        }

        for (int i = hex.Count - 1; i >= 0; i--)
        {
            Console.Write(hex[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int anyBase = int.Parse(Console.ReadLine());
        string numberInAnyBase = Console.ReadLine();
        BigInteger number;            
        int baseToConvertTo = int.Parse(Console.ReadLine());
        BigInteger anyBaseToDecimal = 0;

        if (BigInteger.TryParse(numberInAnyBase, out number))
        {
            if (number < 0)
            {
                number = -number;
            }
            numberInAnyBase = number.ToString();
        }       

        if (anyBase >= 2 && baseToConvertTo <= 16)
        {
            if (anyBase != 10)
            {
                //convert To decimal
                anyBaseToDecimal = toDecimal(numberInAnyBase, anyBase);
            }
            else
            {
                anyBaseToDecimal = BigInteger.Parse(numberInAnyBase);
            }

            if (baseToConvertTo != 10)
            {
                //convert to any other base from decimal
                ConvertToAnyOtherBase(anyBaseToDecimal, baseToConvertTo);
            }
            else
            {
                Console.WriteLine(anyBaseToDecimal);
            }

        }

    }
}

