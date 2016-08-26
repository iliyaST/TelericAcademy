using System;
/*
Problem 13. Binary to Decimal Number
Using loops write a program that converts a binary integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.
*/
class BinaryToDecimal
{
    static void Main()
    {
        string binaryNumber = Console.ReadLine();
        int counter = binaryNumber.Length;
        long result = 0;


        Console.WriteLine();
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            long binaryToHex = 1;
            // Console.Write(binaryNumber.Substring(counter - 1, 1));

            if (binaryNumber.Substring(counter - 1, 1) == "1")
            {
                if (i == 0)
                {
                    binaryToHex = 1;
                }
                for (int j = 1; j <= i; j++)
                {
                    binaryToHex *= 2;
                }
                // Console.Write(binaryToHex + " ");
                result += binaryToHex;
            }
            counter--;

        }
        Console.WriteLine();
        Console.WriteLine(result);
    }
}

