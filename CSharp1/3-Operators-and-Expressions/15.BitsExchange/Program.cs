using System;
using System.Text;
/*
Problem 15.* Bits Exchange
Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
*/
class BitsExchange
{
    static void Main()
    {
        long unsignedInteger = long.Parse(Console.ReadLine().PadLeft(32, '0'));
        string number = Convert.ToString(unsignedInteger, 2).PadLeft(32, '0');
        string sub = number;
        string[] numbers;
        string sub1 = "";
        numbers = new string[number.Length];

        for (int i = 0; i < number.Length; i++)
        {
            numbers[i] = number.Substring(i, 1);
        }
        string a = numbers[28];
        string b = numbers[27];
        string c = numbers[26];
        numbers[26] = numbers[5];
        numbers[27] = numbers[6];
        numbers[28] = numbers[7];
        numbers[7] = a;
        numbers[6] = b;
        numbers[5] = c;
        for (int i = 0; i < number.Length; i++)
        {
            sub1 += numbers[i];
        }

        Console.WriteLine(Convert.ToInt32(sub1, 2));
    }
}


