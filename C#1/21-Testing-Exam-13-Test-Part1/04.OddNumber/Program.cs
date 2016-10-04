using System;

class OddNumber
{
    static void Main()
    {
        long N = long.Parse(Console.ReadLine());
        long oddNumber = 0;

        for (int i = 0; i < N; i++)
        {
            long temp = long.Parse(Console.ReadLine());
            oddNumber ^= temp;
        }

        Console.WriteLine(oddNumber);
    }
}

