using System;

class SumIntegers
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' });
        int Sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            Sum += int.Parse(input[i].ToString());
        }

        Console.WriteLine(Sum);
    }
}

