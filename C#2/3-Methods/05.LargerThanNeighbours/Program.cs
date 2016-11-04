using System;

class LargerThanNeighbours
{
    static int BiggerOrSmallerNeighbours(int[] array, int length)
    {
        int counter = 0;

        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1] && array[i] > array[i - 1])
            {
                counter++;
            }
        }

        return counter;
    }
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(new char[] { ' ' });
        int[] array = new int[N];
        int counter = 0;

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(input[i]);
        }

        counter = BiggerOrSmallerNeighbours(array, N);

        Console.WriteLine(counter);
    }
}

