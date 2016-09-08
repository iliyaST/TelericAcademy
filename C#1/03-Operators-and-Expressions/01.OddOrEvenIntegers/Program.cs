using System;
/*
Problem 1. Odd or Even Integers
Write an expression that checks if given integer is odd or even.
*/
class OddOrEvenIntegers
{
    static void Main()
    {
        int integer = int.Parse(Console.ReadLine());
        if (integer % 2 == 0)
        {
            Console.WriteLine("{0} is even..", integer);
        }
        else
        {
            Console.WriteLine("{0} is odd..", integer);
        }
    }
}
