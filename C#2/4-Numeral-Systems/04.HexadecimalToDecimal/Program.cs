using System;

class HexadecimalToDecimal
{
    static long ToDecimal(string numberInHexadecimal)
    {
        long numberToDecimal = 0;
        long len = numberInHexadecimal.Length;
        long convert;

        for (int i = 0; i < len; i++)
        {
            if (long.TryParse(numberInHexadecimal[i].ToString(), out convert))
            {
                //convert = long.Parse(numberInHexadecimal);
                numberToDecimal += convert*((long)Math.Pow(16, len - 1 - i));
            }
            else
            {
                switch (numberInHexadecimal[i])
                {
                    case 'A': convert = 10; break;
                    case 'B': convert = 11; break;
                    case 'C': convert = 12; break;
                    case 'D': convert = 13; break;
                    case 'E': convert = 14; break;
                    case 'F': convert = 15; break;
                }
                numberToDecimal += convert*(long)Math.Pow( 16, len - 1 - i);
            }
        }

        return numberToDecimal;
    }

    static void Main()
    {
        string numberInHex = Console.ReadLine();

        long numberToDecimal = ToDecimal(numberInHex);

        Console.WriteLine(numberToDecimal);
    }
}

