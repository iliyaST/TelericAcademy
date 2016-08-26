using System;
/*
Problem 5. Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N
Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
Use only one loop. Print the result with 5 digits after the decimal point.
*/
class Calculate
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        int t = 1;
        int m = 1;
        double sum = 1;

        for (int i = 1; i <= n; i++)
        {
            double currentFactioriel = m *= i;
            double currentPow = t *= x;
            double currentTerm = currentFactioriel / currentPow;
            sum += currentTerm;
        }
        Console.WriteLine("{0:F5}", sum);
    }
}

