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

        if (double.TryParse(howManyNumbers, out numbers))
        {
            if (1 <= numbers && numbers <= 1000)
            {
                int counter = 2;
                double randomNumberOne = double.Parse(Console.ReadLine());
                double randomNumberTwo = double.Parse(Console.ReadLine());
                double max = randomNumberOne;
                double min = randomNumberTwo;
                double sum = max + randomNumberTwo;
                double averege = 0;

                if (randomNumberTwo > max)
                {
                    min = max;
                    max = randomNumberTwo;
                }

                while (counter < numbers)
                {
                    double randomNumber = double.Parse(Console.ReadLine());

                    sum += randomNumber;

                    if (randomNumber > max)
                    {
                        max = randomNumber;
                    }
                    else if (randomNumber < min)
                    {
                        min = randomNumber;
                    }

                    counter++;
                }

                averege = sum / numbers;

                Console.WriteLine("min={0:0.00}", min);
                Console.WriteLine("max={0:0.00}", max);
                Console.WriteLine("sum={0:0.00}", sum);
                Console.WriteLine("avg={0:0.00}", averege);
            }
            else
            {
                Console.WriteLine("N is not between 1 and 1000");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for N");
        }
    }
}

