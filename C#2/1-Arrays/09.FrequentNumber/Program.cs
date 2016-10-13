using System;
using System.Collections.Generic;

class FrequentNumber
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        List<int> numbers = new List<int>();
        Dictionary<int, int> pairs = new Dictionary<int, int>();
        int max = 0;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
            numbers.Add(array[i]);
        }

        // List<int> numbers = new List<int> { -999000, -999000, -1, -1, 0, 3,3,3,3, 0, 1, 1, 2, 2 ,4,4,4,7,7,7,8,9,9,8};

        foreach (var number in numbers)
        {
            if (!pairs.ContainsKey(number))
            {
                pairs.Add(number, 0);
            }

            pairs[number]++;
        }

        Console.WriteLine(new string('-', 20));
        int maxNum = 0;
        int maxCount = 0;
        foreach (var pair in pairs)
        {
           if (pair.Value > maxCount)
            {
                maxCount = pair.Value;
                maxNum = pair.Key;
            }
        }

        Console.WriteLine("{0}({1} times)", maxNum, maxCount);
    }
}

