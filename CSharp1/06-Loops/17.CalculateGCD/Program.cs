using System;
/*
Problem 17.* Calculate GCD
Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
Use the Euclidean algorithm (find it in Internet).
*/
class CalculateGCD
{
    static void Main()
    {
        string input = Console.ReadLine();
        int index = input.IndexOf(' ');
        int a = index;
        int b = input.Length - index - 1;
        int firstInteger = Convert.ToInt32(input.Substring(0, index));
        int secondInteger = Convert.ToInt32(input.Substring(a + 1, b));

        if (secondInteger > firstInteger)
        {
            int temp = firstInteger;
            firstInteger = secondInteger;
            secondInteger = temp;
        }
        while (firstInteger % secondInteger != 0)
        {
            int temp = (firstInteger % secondInteger);
            firstInteger = secondInteger;
            secondInteger = temp;
        }
        Console.WriteLine(secondInteger);

    }
}

