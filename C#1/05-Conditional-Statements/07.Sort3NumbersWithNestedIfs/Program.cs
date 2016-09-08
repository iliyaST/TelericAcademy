using System;
/*
Problem 7. Sort 3 Numbers with Nested Ifs
Write a program that enters 3 real numbers and prints them sorted in descending order.
Use nested if statements.
Note: Don’t use arrays and the built-in sorting functionality. 
*/
class Sort3NumbersWithNestedIfs
{
    static void Main()
    {
        double numberOne = double.Parse(Console.ReadLine());
        double numberTwo = double.Parse(Console.ReadLine());
        double numberThree = double.Parse(Console.ReadLine());
        double max = numberOne;
        double min = numberTwo;
        double middle = numberThree;

        if (numberOne < min)
        {
            min = numberOne;
            if (numberTwo < numberThree)
            {
                middle = numberTwo;
            }
            else
            {
                middle = numberThree;
            }
        }
        if (numberThree < min)
        {
            min = numberThree;
            if (numberOne < numberTwo)
            {
                middle = numberOne;
            }
            else
            {
                middle = numberTwo;
            }
        }

        if (numberThree > max)
        {
            max = numberThree;
            if (numberTwo > numberOne)
            {
                middle = numberTwo;
            }
            else
            {
                middle = numberOne;
            }
        }
        if (numberTwo > max)
        {
            max = numberTwo;
            if (numberThree > numberOne)
            {
                middle = numberThree;
            }
            else
            {
                middle = numberOne;
            }
        }

        Console.WriteLine("{0} {1} {2}", max, middle, min);
    }
}

