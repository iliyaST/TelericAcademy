using System;

class BinarySearch
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        bool exists = false;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int X = int.Parse(Console.ReadLine());

        Array.Sort(array);


        if (array[N / 2] == X)
        {
            Console.WriteLine(N / 2);
            exists = true;
        }

        else if (array[N / 2] > X)
        {
            for (int t = 0; t < N / 2; t++)
            {
                if (array[t] == X)
                {
                    Console.WriteLine(t);
                    exists = true;
                    break;
                }
            }
        }

        else if (array[N / 2] < X)
        {
            for (int t = N/2; t < N; t++)
            {
                if (array[t] == X)
                {
                    Console.WriteLine(t);
                    exists = true;
                    break;
                }
            }
        }

        if(exists == false)
        {
            Console.WriteLine(-1);
        }
    }
}


