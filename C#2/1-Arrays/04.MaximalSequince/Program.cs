using System;

class MaximalSequince
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        int max = 0;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            if (i == N - 1)
            {
                break;
            }
            int count = 1;
            int iCounter = i;
            while (true)
            {
                if (array[i] == array[iCounter + 1])
                {
                    count++;
                }
                else
                {
                    if (max < count)
                    {
                        max = count;
                    }
                    i += count - 1;
                    break;
                }
                iCounter++;
                if (iCounter >= N - 1)
                {
                    break;
                }
            }
            if (max < count)
            {
                max = count;
            }
        }

        Console.WriteLine(max);
    }
}

