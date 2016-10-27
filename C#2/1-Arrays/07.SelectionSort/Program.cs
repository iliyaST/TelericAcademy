using System;


class SelectionSort
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        int min = int.MaxValue;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                if (array[j] > array[i])
                {
                    min = array[j];
                    array[j] = array[i];
                    array[i] = min;
                }
            }
        }

        for (int i = N-1; i >=0; i--)
        {
            Console.WriteLine(array[i]);
        }
    }
}

