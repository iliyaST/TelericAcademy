using System;

class FindSumInArray
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int S = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        int currentSum = 0;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            if ((currentSum += array[i]) < S)
            {
                currentSum += array[i];
            }
            else if ((currentSum += array[i]) == S)
            {
                Console.WriteLine(array[i]);
                Environment.Exit(0);
            }
            int iCounter = i;

            while (true)
            {
                if ((currentSum += array[iCounter]) < 11)
                {
                    currentSum += array[iCounter];
                }
                else if((currentSum += array[i]) == S)
            }
        }

    }
}

