using System;

class SortingArray
{
    static void Sort(int[] array)
    {
        Array.Sort(array);
    }

    static void Main()
    {
        int arrayLength = int.Parse(Console.ReadLine());
        int[] array = new int[arrayLength];
        string[] input = Console.ReadLine().Split(new char[] { ' ' });

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(input[i]);
        }

        Sort(array);

        Console.WriteLine(String.Join(" ", array));
    }
}

