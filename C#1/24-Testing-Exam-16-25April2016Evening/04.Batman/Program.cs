using System;

class Batman
{
    static void Main()
    {
        int S = int.Parse(Console.ReadLine());
        string charC = Console.ReadLine();
        char C = charC[0];
        int len = (S - 5) / 2 + 1;
        int totalWidth = S * 3;
        int globalCount = 0;
        int hight = S + (S - 5) / 2;

        Console.Write(new string(C, S));
        Console.Write(new string(' ', S));
        Console.WriteLine(new string(C, S));
        globalCount++;
        for (int i = 1; i <= len; i++)
        {
            if (i == len)
            {
                Console.Write(new string(' ', i));
                Console.Write(new string(C, S - i));
                Console.Write(new string(' ', len));
                Console.Write(new string(C, 1));
                Console.Write(new string(' ', 1));
                Console.Write(new string(C, 1));
                Console.Write(new string(' ', len));
                Console.Write(new string(C, S - i));
                Console.WriteLine(new string(' ', i));
                globalCount++;
                continue;
            }
            Console.Write(new string(' ', i));
            Console.Write(new string(C, S - i));
            Console.Write(new string(' ', S));
            Console.Write(new string(C, S - i));
            Console.WriteLine(new string(' ', i));
            globalCount++;
        }        

        for (int i = 0; i < S/3; i++)
        {
            Console.Write(new string(' ', len + 1));
            Console.Write(new string(C, S * 2 + 1));
            Console.WriteLine(new string(' ', len + 1));
        }

        int counter = S - 2;
        while (counter != 1)
        {
            Console.Write(new string(' ', (totalWidth - counter) / 2));
            Console.Write(new string(C, counter));
            Console.WriteLine(new string(' ', (totalWidth - counter) / 2));
            counter -= 2;
        }
        Console.Write(new string(' ', (totalWidth - 1) / 2));
        Console.Write(new string(C, 1));
        Console.WriteLine(new string(' ', (totalWidth - 1) / 2));

    }
}

