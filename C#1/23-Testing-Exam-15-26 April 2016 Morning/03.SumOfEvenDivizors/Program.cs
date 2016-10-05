using System;

class SumOfEvenDivisors
{
    static void Main()
    {
        int A = int.Parse(Console.ReadLine());
        int B = int.Parse(Console.ReadLine());

        int totalSum = 0;

        for (int i = A; i <= B; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0 && j % 2 == 0)
                {
                    totalSum += j;
                }
            }
        }

        Console.WriteLine(totalSum);
    }
}

