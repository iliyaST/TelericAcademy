using System;
/*
Write a program that finds the biggest of five numbers by using only five if statements.
*/
class BiggestOfFive
{
    static void Main()
    {
        double number0 = double.Parse(Console.ReadLine());
        double max = number0;
        double number1 = double.Parse(Console.ReadLine());
        double number2 = double.Parse(Console.ReadLine());
        double number3 = double.Parse(Console.ReadLine());
        double number4 = double.Parse(Console.ReadLine());

        if (number1 > max)
        {
            max = number1;
        }
        if (number2 > max)
        {
            max = number2;
        }
        if (number3 > max)
        {
            max = number3;
        }
        if (number4 > max)
        {
            max = number4;
        }

        Console.WriteLine(max);
    }
}

