using System;

class Cube
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.Write(new string(' ', n - 1));
        Console.WriteLine(new string(':', n));
        for (int i = 0; i < n - 2; i++)
        {
            Console.Write(new string(' ', n - 2 - i));
            Console.Write(new string(':', 1));
            Console.Write(new string('/', n - 2));
            Console.Write(new string(':', 1));
            Console.Write(new string('X', 0 + i));
            Console.WriteLine(new string(':', 1));
        }
        Console.Write(new string(':', n));
        Console.Write(new string('X', n - 2));
        Console.WriteLine(new string(':', 1));
        for (int i = 0; i < n - 2; i++)
        {
            Console.Write(new string(':', 1));
            Console.Write(new string(' ', n - 2));
            Console.Write(new string(':', 1));
            Console.Write(new string('X', n-3-i));
            Console.WriteLine(new string(':', 1));
        }
        Console.WriteLine(new string(':', n));
    }
}

