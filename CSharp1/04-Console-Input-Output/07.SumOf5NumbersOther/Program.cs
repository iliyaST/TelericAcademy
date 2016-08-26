using System;
/*
Problem 7. Sum of 5 Numbers
Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
*/
class SumbOf5NumbersOther
{
    static void Main()
    {

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        Console.WriteLine(a + b + c + d + e);
    }
}

