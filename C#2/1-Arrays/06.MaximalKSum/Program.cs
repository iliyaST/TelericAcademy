using System;
using System.Collections.Generic;

class MaximalKSum
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        List<int> maxElements = new List<int>();
        int max = int.MinValue;
        int counter = 0;
        int MaximalSum = 0;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        while (counter != K)
        {
            for (int i = 0; i < N; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }
            for (int i = 0; i < N; i++)
            {
                if(max==array[i])
                {
                    array[i] = int.MinValue;
                }
            }
            maxElements.Add(max);
            max = int.MinValue;
            counter++;
        }

        foreach (var item in maxElements)
        {
            MaximalSum += item;
        }

        Console.WriteLine(MaximalSum);
    }
}
