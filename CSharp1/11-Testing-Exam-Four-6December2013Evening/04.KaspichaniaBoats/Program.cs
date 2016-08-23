using System;

class KaspichaniaBoats
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.Write(new string('.',n));
        Console.Write(new string('*',1));
        Console.WriteLine(new string('.',n));
        Console.Write(new string('.', n-1));
        Console.Write(new string('*', 3));
        Console.WriteLine(new string('.', n-1));

        for (int i = 0; i < n - 2; i++)
        {
            Console.Write(new string('.', n-2-i));
            Console.Write(new string('*',1));
            Console.Write(new string('.',1+i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', 1 + i));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', n - 2 - i));
        }
        Console.WriteLine(new string('*',n*2+1));
        for (int i = 0; i < (((n*2+1)-n)/2)-1; i++)
        {
            Console.Write(new string('.',1+i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', n-2 - i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', n-2 - i));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', 1 + i));
        }
        Console.Write(new string('.', (n*2+1-n)/2));
        Console.Write(new string('*', n));
        Console.WriteLine(new string('.', (n * 2 + 1 - n) / 2));
    }
}

