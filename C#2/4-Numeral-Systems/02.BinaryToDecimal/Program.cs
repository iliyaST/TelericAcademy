using System;

class BinaryToDecimal
{
    static long ToDecimal(string numberInBinary)
    {
        long numberToDecimal = 0;
        long len = numberInBinary.Length;

        for (int i = 0; i < len; i++)
        {
            if (numberInBinary[i] == '1')
            {
                numberToDecimal += (long)Math.Pow(2, len-1-i);
            }
        }

        return numberToDecimal;
    }

    static void Main()
    {
        string numberToBinary = Console.ReadLine();

        long result = ToDecimal(numberToBinary);

        Console.WriteLine(result);
    }
}

