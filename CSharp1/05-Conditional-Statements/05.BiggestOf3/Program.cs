using System;
/*
Problem 5. The Biggest of 3 Numbers
Write a program that finds the biggest of three numbers.
*/
class BiggestOf3
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());
        double min;
        double max;

        if (firstNumber < thirdNumber && firstNumber == secondNumber)
        {
            Console.WriteLine(thirdNumber);
        }
        else if (secondNumber < firstNumber && secondNumber == thirdNumber)
        {
            Console.WriteLine(firstNumber);
        }
        else if (thirdNumber < secondNumber && thirdNumber == firstNumber)
        {
            Console.WriteLine(secondNumber);
        }
        else if (firstNumber == secondNumber && firstNumber == thirdNumber)
        {
            Console.WriteLine(firstNumber);
        }
        if (firstNumber < secondNumber && firstNumber < thirdNumber)
        {
            min = firstNumber;
            if (secondNumber < thirdNumber)
            {
                max = thirdNumber;
            }
            else
            {
                max = secondNumber;
            }
            Console.WriteLine("{0}", max);

        }
        else if (secondNumber < firstNumber && secondNumber < thirdNumber)
        {
            min = secondNumber;
            if (firstNumber < thirdNumber)
            {
                max = thirdNumber;
            }
            else
            {
                max = firstNumber;
            }
            Console.WriteLine("{0}", max);

        }
        else if (thirdNumber < firstNumber && thirdNumber < secondNumber)
        {
            min = thirdNumber;
            if (firstNumber < secondNumber)
            {
                max = secondNumber;
            }
            else
            {
                max = firstNumber;
            }
            Console.WriteLine("{0}", max);
        }
    }
}

