using System;
using System.Collections.Generic;
using System.Numerics;

class BunnyFactory
{
    static void Main()
    {
        List<int> list = new List<int>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            list.Add(int.Parse(input));
        }

        var resultedList = new List<int>();
        int cycle = 1;

        while (true)
        {
            int currentElSum = 0;

            if (cycle > list.Count)
            {
                break;
            }

            for (int i = 0; i < cycle; i++)
            {
                currentElSum += list[i];
            }

            if (currentElSum > list.Count - cycle)
            {
                break;
            }

            BigInteger currentSum = 0;
            BigInteger currentProduct = 1;

            for (int i = cycle; i < cycle + currentElSum; i++)
            {
                currentSum += list[i];
                currentProduct *= list[i];
            }

            string sub = "";
            for (int i = cycle + currentElSum; i < list.Count; i++)
            {
                sub += list[i];
            }

            sub = currentSum.ToString() + currentProduct.ToString() + sub;
            list.Clear();

            for (int i = 0; i < sub.Length; i++)
            {
                if (sub[i] == '1' || sub[i] == '0')
                {
                    continue;
                }
                list.Add(int.Parse(sub[i].ToString()));
            }
            cycle++;
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                Console.Write(list[i]);
                break;
            }
            Console.Write(list[i] + " ");
        }

        Console.WriteLine();
    }
}
