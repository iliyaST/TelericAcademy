using System;
/*
Problem 15. Decimal to Hexadecimal Number
Using loops write a program that converts an integer number to its hexadecimal representation.
The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality.
*/
class DecimalToHexaDecimal
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        long binaryInput = input;
        string convert = "";
        string result = "";
        if (input == 0)
        {
            result = "0";
        }
        
        while (input > 0)
        {
            //Console.WriteLine(input % 16);

            if (input % 16 > 9)
            {
                if (input % 16 == 10)
                {
                    convert += "A";
                }
                if (input % 16 == 11)
                {
                    convert += "B";
                }
                if (input % 16 == 12)
                {
                    convert += "C";
                }
                if (input % 16 == 13)
                {
                    convert += "D";
                }
                if (input % 16 == 14)
                {
                    convert += "E";
                }
                if (input % 16 == 15)
                {
                    convert += "F";
                }
            }
            else
            {
                convert += input % 16;
            }
            input /= 16;
        }
        //Console.WriteLine(convert);
        int counter = convert.Length;

        for (int i = 0; i < convert.Length; i++)
        {
            result += convert.Substring(counter - 1, 1);
            counter--;
        }

        Console.WriteLine(result);
    }
}