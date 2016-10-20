using System;


class Vectors
{
    static int N;
    static int[] array;
    static int counter;
    static bool[] used;

    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        array = new int[N];
        combination(0, 1, N);
        Console.WriteLine(counter);
    }

    public static void combination(int index, int start, int end)
    {
        if (index == N)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("({0})", String.Join(", ", array));
            }
            counter++;
            return;
        }
        for (int i = start; i <= end; i++)
        {
            array[index] = i;
            combination(index + 1, start, end);
        }
    }
}

