using System;

class Eggcelent
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.Write(new string('.', n + 1));
        Console.Write(new string('*', n - 1));
        Console.WriteLine(new string('.', n + 1));
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', n - 1 - (i * 2)));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', ((((3 * n) - 1) - 2) - (2 * (n - 1 - (i * 2)))) + 2));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', n - 1 - (i * 2)));
        }
        if (n >= 4)
        {
            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.Write(new string('.', 1));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', (n * 3 - 3)));
                Console.Write(new string('*', 1));
                Console.WriteLine(new string('.', 1));
            }
        }
        Console.Write(new string('.', 1));
        Console.Write(new string('*', 1));
        for (int i = 0; i < (n * 3 - 3) / 2; i++)
        {
            Console.Write(new string('@', 1));
            Console.Write(new string('.', 1));
        }
        Console.Write(new string('@', 1));
        Console.Write(new string('*', 1));
        Console.WriteLine(new string('.', 1));
        Console.Write(new string('.', 1));
        Console.Write(new string('*', 1));
        for (int i = 0; i < (n * 3 - 3) / 2; i++)
        {
            Console.Write(new string('.', 1));
            Console.Write(new string('@', 1));
        }
        Console.Write(new string('.', 1));
        Console.Write(new string('*', 1));
        Console.WriteLine(new string('.', 1));
        if (n >= 4)
        {
            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.Write(new string('.', 1));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', (n * 3 - 3)));
                Console.Write(new string('*', 1));
                Console.WriteLine(new string('.', 1));
            }
        }
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', 3 + (i * 2)));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', ((n * 3 - 4) - ((3 + (i * 2)*2)))));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', 3+ (i * 2)));
        }
        Console.Write(new string('.', n + 1));
        Console.Write(new string('*', n - 1));
        Console.WriteLine(new string('.', n + 1));
    }
}



