using System;

class Cuber
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        Console.Write(new string(' ', N - 1));
        Console.WriteLine(new string(':', N));
        for (int i = 0; i < N - 2; i++)
        {
            Console.Write(new string(' ', N - 2 - i));
            Console.Write(new string(':', 1));
            Console.Write(new string('/', N - 2));
            Console.Write(new string(':', 1));
            Console.Write(new string('X', 0 + i));
            Console.WriteLine(new string(':', 1));
        }
        Console.Write(new string(':', N));
        Console.Write(new string('X', N - 2));
        Console.WriteLine(new string(':', 1));
        for (int i = 0; i < N - 2; i++)
        {
            Console.Write(new string(':', 1));
            Console.Write(new string(' ', N - 2));
            Console.Write(new string(':', 1));
            Console.Write(new string('X', N - 3 - i));
            Console.WriteLine(new string(':', 1));
        }
        Console.WriteLine(new string(':', N));
    }
}

