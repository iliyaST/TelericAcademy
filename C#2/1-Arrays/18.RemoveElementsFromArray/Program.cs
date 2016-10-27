using System;
using System.Collections.Generic;
using System.Linq;

class RemoveElementsFromArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        int[] LIS = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            LIS[i] = 1;
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] >= numbers[j])
                {
                    if (LIS[j] + 1 > LIS[i])
                    {
                        LIS[i]++;
                    }
                }
            }
        }

        //for (int i = 0; i < n; i++)
        //{
        //    Console.Write(LIS[i] + " ");
        //}
        //Console.WriteLine();
        Console.WriteLine(n-LIS.Max());
    }
}



