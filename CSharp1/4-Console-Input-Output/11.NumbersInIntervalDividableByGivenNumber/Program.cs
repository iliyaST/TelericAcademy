using System;
/*
Problem 11.* Numbers in Interval Dividable by Given Number
Write a program that reads two positive integer numbers and prints 
how many numbers p exist between them such that the reminder of the division by 5 is 0.
*/
class Interval
{
    static void Main()
    {
        int firstPositiveInteger = int.Parse(Console.ReadLine());
        int secondPositiveInteger = int.Parse(Console.ReadLine());
        int count = 0;

        for (int i = firstPositiveInteger + 1; i < secondPositiveInteger; i++)
        {
            if (i % 5 == 0)
            {
                count++;
            }
        }
        Console.WriteLine(count);

    }
}

