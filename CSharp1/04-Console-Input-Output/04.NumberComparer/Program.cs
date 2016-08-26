using System;
/*
Problem 4. Number Comparer
Write a program that gets two numbers from the console and prints the greater of them.
Try to implement this without if statements.
*/
class Program
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());

        Console.WriteLine(firstNumber>secondNumber?firstNumber:secondNumber);
    }
}

