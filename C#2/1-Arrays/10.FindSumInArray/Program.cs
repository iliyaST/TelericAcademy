using System;
using System.Collections.Generic;

class FindSumInArray
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int S = int.Parse(Console.ReadLine());
        List<int> subArray = new List<int>();
        int[] mainArray = new int[N];
        int currentSum = 0;
        int counter = 0;

        for (int i = 0; i < N; i++)
        {
            mainArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            if ((currentSum + mainArray[i]) < S)
            {
                currentSum += mainArray[i];
                subArray.Add(mainArray[i]);
                counter++;
            }
            else if ((currentSum + mainArray[i]) == S)
            {
                currentSum += mainArray[i];
                subArray.Add(mainArray[i]);
                counter++;
                for (int t = 0; t < counter; t++)
                {
                    Console.Write(subArray[t]+" ");
                }
                Console.WriteLine();
                subArray.Clear();
                currentSum = 0;
                counter = 0;
            }
            else if ((currentSum + mainArray[i]) > S)
            { 
                counter = 0;
                i += -1;
                subArray.Clear();
                currentSum = 0;
            }
        }
    }
}

