using System;
using System.Collections.Generic;

class SubsetKWithSumS
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        int[] maxArray = new int[K];
        int counter = 0;
        int[] array = new int[N];
        int max = int.MinValue;
        int result = 0;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());           
        }

        while (counter < K)
        {
            for (int i = 0; i < N; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    maxArray[counter] = max;
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (max == array[i])
                {
                    array[i] = int.MinValue;
                    max = int.MinValue;
                }
            }
            counter++;
        }

        for (int i = 0; i < K; i++)
        {
            result += maxArray[i];
        }

        Console.WriteLine(result);
    }
}

