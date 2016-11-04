using System;

class FirstLargerThanNeighbours
{
    static int BiggerOrSmallerNeighbours(int[] array, int length)
    {
        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1] && array[i] > array[i - 1])
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(new char[] { ' ' });
        int[] array = new int[N];
        int index = 0;

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(input[i]);
        }

        index = BiggerOrSmallerNeighbours(array, N);

        Console.WriteLine(index);
    }
}

