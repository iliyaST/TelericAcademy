using System;
/*
Write a program that reads 3 real numbers from the console and prints their sum.
*/
class SumOf3Numbers
{
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        int number3 = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}", number1 + number2 + number3);
    }
}

