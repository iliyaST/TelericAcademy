using System;
/*
Problem 10. Fibonacci Numbers
Write a program that reads a number n and prints on the console the first n 
members of the Fibonacci sequence (at a single line, separated by comma and space - ,) :
0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
*/
class Fibonacci
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int firstNumber = 0;
        int secondNumber = 1;

        Console.Write(firstNumber);
        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(", {0}", secondNumber);
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber += temp;
        }
    }
}


