using System;


class ForestRoad
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int posStar = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (posStar == i && posStar == j)
                {
                    Console.Write("*");
                    posStar++;
                    continue;
                }
                Console.Write(".");
            }
            Console.WriteLine();
        }
        for (int i = N - 2; i >= 0; i--)
        {
            posStar = 0;
            for (int j = 0; j < N; j++)
            {
                if (posStar == i)
                {
                    Console.Write("*");
                    posStar++;
                }
                else
                {
                    Console.Write(".");
                    posStar++;
                }
            }
            Console.WriteLine();
        }
    }
}

