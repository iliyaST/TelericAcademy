using System;

class TelericLogo
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int counter = 0;
        int counterA = 0;
        int counterB = 0;
        int counterC = 0;
        int counterD = 0;
        int counterE = 0;

        for (int i = 0; i < N / 2 + 1; i++)
        {
            if (i > 0)
            {
                Console.Write(new string('.', N / 2 - i));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', 1 + counter));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', (1 + 2 * (N - 2)) - i * 2));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', 1 + counter));
                Console.Write(new string('*', 1));
                Console.WriteLine(new string('.', N / 2 - i));
                counter += 2;
                counterA = ((1 + 2 * (N - 2)) - i * 2);
                continue;
            }
            Console.Write(new string('.', N / 2 - i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', 1 + 2 * (N - 2) - i * 2));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', N / 2 - i));
        }
        if (N < 5)
        {
            Console.Write(new string('.', N));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', N));
        }
        else
        {
            for (int i = 0; i < (N - (N / 2 + 1)) - 1; i++)
            {
                Console.Write(new string('.', N + counterB));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', counterA - 2 - counterC));
                Console.Write(new string('*', 1));
                Console.WriteLine(new string('.', N + counterB));
                counterB ++;
                counterC += 2;
            }
            Console.Write(new string('.', N + counterB));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', N + counterB));
        }
        for (int i = 0; i < N-1; i++)
        {
            Console.Write(new string('.', N + counterB-1-i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', 1+i*2));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', N + counterB-1-i));
            counterD = N + counterB - 1 - i;
            counterE = 1 + i * 2;
        }
        for (int i = 0; i < N - 1; i++)
        {
            Console.Write(new string('.', counterD+i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', counterE-i*2));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.',counterD+i));
        }
        Console.Write(new string('.', N + counterB));
        Console.Write(new string('*', 1));
        Console.WriteLine(new string('.', N + counterB));
    }
}

