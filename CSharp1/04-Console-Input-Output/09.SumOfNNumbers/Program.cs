using System;
/*
Problem 9. Sum of n Numbers
Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum.
*/
class SumOfNNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += int.Parse(Console.ReadLine());
        }
        Console.WriteLine(sum);

    }
}

