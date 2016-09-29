using System;

class Lines
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];
        int max = 0;
        int maxCount = 0;

        for (int i = 0; i < 8; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            int q = 7;
            for (int j = 0; j < 8; j++)
            {
                int mask = 1 << j;
                int nAndMask = temp & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    matrix[i, q] = 1;
                }
                q--;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int len = 0;
                while (j < 8 && matrix[i, j] == 1)
                {
                    j++;
                    len++;
                }             
                if (max < len)
                {
                    max = len;
                    maxCount = 0;
                }
                if (len == max)
                {
                    maxCount++;
                }
            }
        }

        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                int len = 0;
                while (i < 8 && matrix[i, j] == 1)
                {
                    i++;
                    len++;
                }
                if (max < len)
                {
                    max = len;
                    maxCount = 0;
                }
                if (len == max)
                {
                    maxCount++;
                }
            }
        }
        if (max == 1)
        {
            maxCount /= 2;
        }
        Console.WriteLine(max);
        Console.WriteLine(maxCount);
    }
}

