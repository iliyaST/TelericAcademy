using System;
/*
Problem 3. Min, Max, Sum and Average of N Numbers
Write a program that reads from the console a sequence of n integer numbers and returns the minimal,
the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
The output is like in the examples below.
*/
class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        string howManyNumbers = Console.ReadLine();
        double numbers;
        double minValue = double.MaxValue;
        double maxValue = double.MinValue;
        double sum = 0;
        if (double.TryParse(howManyNumbers, out numbers))
        {
            for (int i = 0; i < numbers; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());
                if (currentNumber > maxValue)
                {
                    maxValue = currentNumber;
                }
                if (currentNumber < minValue)
                {
                    minValue = currentNumber;
                }
                sum += currentNumber;
            }
            Console.WriteLine("min={0:F2} ", minValue);
            Console.WriteLine("max={0:F2} ", maxValue);
            Console.WriteLine("sum={0:F2} ", sum);
            Console.WriteLine("avg={0:F2} ", sum / numbers);
        }
    }
}

