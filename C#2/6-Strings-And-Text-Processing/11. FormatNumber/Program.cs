using System;

class FormatNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("{0,15:D}", number); // Decimal
        Console.WriteLine("{0,15:X}", number); // Hexadecimal
        Console.WriteLine("{0,15:P}", number); // Percentage
        Console.WriteLine("{0,15:E}", number); // Scientific notation

    }
}

