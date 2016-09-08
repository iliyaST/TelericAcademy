using System;
using System.Numerics;

class SubsetSumbs
{
    static void Main()
    {       
        long S = long.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        long[] array = new long[N];
        long maxCombinations = (long)(Math.Pow(2, N)) - 1;
        long subsetCount = 0;

        for (int i = 0; i < N; i++)
        {
            long temp = long.Parse(Console.ReadLine());
            array[i] = temp;
        }

        for (int i = 1; i <= maxCombinations; i++)
        {
            long currentSum = 0;
            for (int j = 0; j < N; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    currentSum += array[j];
                }             
            }
            if (currentSum == S)
            {
                subsetCount++;
            }
        }
        Console.WriteLine(subsetCount);
    }
}
