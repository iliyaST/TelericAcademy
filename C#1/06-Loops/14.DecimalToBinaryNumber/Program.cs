using System;
/*
Problem 14. Decimal to Binary Number
Using loops write a program that converts an integer number to its binary representation.
The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality.
*/
class DecimalToBinary
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        string convertToBinary = "";
        string result = "";

        while (decimalNumber >= 1)
        {
            convertToBinary += decimalNumber % 2;
            decimalNumber /= 2;
        }


        int counter = convertToBinary.Length;

        for (int i = 0; i < convertToBinary.Length; i++)
        {
            result += convertToBinary.Substring(counter - 1, 1);
            counter--;
        }

        Console.WriteLine(result);

    }
}

