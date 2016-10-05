using System;

class MalkoKote
{
    static void Main()
    {
        int S = int.Parse(Console.ReadLine());
        string Char = Console.ReadLine();
        char C = Char[0];
        int width = ((S - 10) / 2) + 9;
        int space = (S - 10) / 4 + 1;
        int counter = 0;

        Console.Write(new string(' ', 1));
        Console.Write(new string(C, 1));
        Console.Write(new string(' ', (S - 10) / 4 + 1));
        Console.Write(new string(C, 1));
        Console.WriteLine(new string(' ', width - 3 - space));
        counter++;

        for (int i = 0; i < space; i++)
        {
            Console.Write(new string(' ', 1));
            Console.Write(new string(C, space + 2));
            Console.WriteLine(new string(' ', width - 3 - space));
            counter++;
        }

        for (int i = 0; i < space; i++)
        {
            Console.Write(new string(' ', 2));
            Console.Write(new string(C, space));
            Console.WriteLine(new string(' ', width - 2 - space));
            counter++;
        }

        for (int i = 0; i < space; i++)
        {
            Console.Write(new string(' ', 1));
            Console.Write(new string(C, space + 2));
            Console.WriteLine(new string(' ', width - 3 - space));
            counter++;
        }

        Console.Write(new string(' ', 1));
        Console.Write(new string(C, space + 2));
        Console.Write(new string(' ', width - 1 - (2 * space + 3)));
        Console.WriteLine(new string(C, space + 1));
        counter++;

        for (int i = 0; i < S - counter - 2; i++)
        {
            Console.Write(new string(C, space + 4));
            Console.Write(new string(' ', 2));
            Console.Write(new string(C, 1));
            Console.WriteLine(new string(' ', space));
        }

        Console.Write(new string(C, space + 4));
        Console.Write(new string(' ', 1));
        Console.Write(new string(C, 2));
        Console.WriteLine(new string(' ', space));

        Console.Write(new string(' ', 1));
        Console.WriteLine(new string(C, space + 5));
    }
}

