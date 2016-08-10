using System;

class Fire
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.Write(new string('.', ((n - 2) / 2)));
        Console.Write(new string('#', 2));
        Console.WriteLine(new string('.', (n - 2) / 2));
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', (n / 2 - 2) - i));
            Console.Write(new string('#', 1));
            Console.Write(new string('.', 2 + i * 2));
            Console.Write(new string('#', 1));
            Console.WriteLine(new string('.', (n / 2 - 2) - i));
        }
        Console.Write(new string('#', 1));
        Console.Write(new string('.', n - 2));
        Console.WriteLine(new string('#', 1));
        for (int i = 0; i < (n - 2) / 4; i++)
        {
            Console.Write(new string('.', 1 + i));
            Console.Write(new string('#', 1));
            Console.Write(new string('.', (n - 4) - i * 2));
            Console.Write(new string('#', 1));
            Console.WriteLine(new string('.', 1 + i));
        }
        Console.WriteLine(new string('-', n));
        Console.Write(new string('\\', n / 2));
        Console.WriteLine(new string('/', n / 2));
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', 1 + i));
            Console.Write(new string('\\', n / 2 - 1 - i));
            Console.Write(new string('/', n / 2 - 1 - i));
            Console.WriteLine(new string('.', 1 + i));
        }
    }
}

