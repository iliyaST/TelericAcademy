using System;

class UnicodeCharacters
{
    static void Main()
    {
        string text = Console.ReadLine();

        foreach (var ch in text)
        {
            Console.Write("\\u{0:x4}", (int)ch);
        }

        Console.WriteLine();
    }
}

