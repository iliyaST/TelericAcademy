using System;

class SortByStringLendth
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] array = new string[N];
        int[] newArray = new int[N];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Console.ReadLine();
        }

        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i].Length;
        }

        Array.Sort(newArray);

        for (int i = 0; i < newArray.Length; i++)
        {
            Console.Write(newArray[i] + " ");
        }

        Console.WriteLine();
    }
}

