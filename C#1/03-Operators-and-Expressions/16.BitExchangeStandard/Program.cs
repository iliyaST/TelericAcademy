using System;
/*
Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
*/
class ExchangeBits
{
    static void Main()
    {
        Console.Write("Please enter number:");
        int number = int.Parse(Console.ReadLine());
        int result = number;
        int firstBit, secondBit;
        
        for (int i = 0; i < 3; i++)
        {
            firstBit = 3 + i;
            secondBit = 24 + i;
            result = ((number >> firstBit) % 2) == 1 ? result | (1 << secondBit) : result & ~(1 << secondBit);
            result = ((number >> secondBit) % 2) == 1 ? result | (1 << firstBit) : result & ~(1 << firstBit);
        }

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
    }
}
