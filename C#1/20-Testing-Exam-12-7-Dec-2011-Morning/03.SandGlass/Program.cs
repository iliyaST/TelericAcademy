using System;

class SandGlass
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('*', N));
        for (int i = 0; i < (N - 1) / 2; i++)
        {
            Console.Write(new string('.', 1 + i));
            Console.Write(new string('*', N - (2 * (1 + i))));
            Console.WriteLine(new string('.', 1 + i));
        }
        for (int i = (N - 2) / 2; i >= 1; i--)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('*', N - (2 * i)));
            Console.WriteLine(new string('.', i));
        }
        Console.WriteLine(new string('*', N));
    }
}

