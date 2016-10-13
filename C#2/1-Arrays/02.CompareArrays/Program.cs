using System;

class CompareArrays
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] array1 = new int[N];
        int[] array2 = new int[N];
        bool areEqual = true;

        for (int i = 0; i < N; i++)
        {
            array1[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < N; i++)
        {
            array2[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            if (array1[i] != array2[i])
            {
                areEqual = false;
                break;
            }
        }

        if (areEqual == true)
        {
            Console.WriteLine("Equal");
        }
        else
        {
            Console.WriteLine("Not equal");
        }
    }
}

