using System;
/*
Problem 15. Hexadecimal to Decimal Number
Using loops write a program that converts a hexadecimal integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.
*/
class HexadecimalToDecimal
{
    static void Main()
    {
        string hexadecimalNumber = Console.ReadLine();
        int currentChar;
        int counter = hexadecimalNumber.Length;
        long result = 0;

        for (int i = 0; i < hexadecimalNumber.Length; i++)
        {
            long temp = 1;
            long hexToDecimal = 1;
            if (int.TryParse(hexadecimalNumber.Substring(counter - 1, 1), out currentChar))
            {
                currentChar = Convert.ToInt32(hexadecimalNumber.Substring(counter - 1, 1));
            }
            else
            {
                //Console.Write(hexadecimalNumber.Substring(counter - 1, 1));

                if (hexadecimalNumber.Substring(counter - 1, 1) == "A")
                {
                    currentChar = 10;
                }
                if (hexadecimalNumber.Substring(counter - 1, 1) == "B")
                {
                    currentChar = 11;
                }
                if (hexadecimalNumber.Substring(counter - 1, 1) == "C")
                {
                    currentChar = 12;
                }
                if (hexadecimalNumber.Substring(counter - 1, 1) == "D")
                {
                    currentChar = 13;
                }
                if (hexadecimalNumber.Substring(counter - 1, 1) == "E")
                {
                    currentChar = 14;
                }
                if (hexadecimalNumber.Substring(counter - 1, 1) == "F")
                {
                    currentChar = 15;
                }
            }

            for (int j = 1; j <= i; j++)
            {
                hexToDecimal = temp *= 16;
            }
            result += (currentChar * hexToDecimal);
            counter--;

        }
        Console.WriteLine(result);

    }
}
