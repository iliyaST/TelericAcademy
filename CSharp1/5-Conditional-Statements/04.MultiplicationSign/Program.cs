using System;
/*
Problem 4. Multiplication Sign
Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
Use a sequence of if operators.
*/
class MultiplicationSign
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());

        if (firstNumber * secondNumber * thirdNumber < 0)
        {
            Console.WriteLine("-");
        }
        else if (firstNumber * secondNumber * thirdNumber == 0)
        {
            Console.WriteLine("0");
        }
        else
        {
            Console.WriteLine("+");
        }

    }
}

