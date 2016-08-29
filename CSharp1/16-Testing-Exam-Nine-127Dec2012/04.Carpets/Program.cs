using System;

class Carpet
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int counter = 0;

        //top
        while (counter != N/2)
        {
            Console.Write(new string('.', N / 2 - 1 - counter));
            for (int i = 0; i <= counter; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            if (counter % 2 == 0)
            {
                for (int x = 0; x <= counter; x++)
                {
                    if (x % 2 == 0)
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            else
            {

                for (int y = 0; y <= counter; y++)
                {
                    if (y % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\\");
                    }
                }
            }
            Console.Write(new string('.', N / 2 - 1 - counter));
            Console.WriteLine();
            counter++;
        }
        counter = N / 2;

        //bottom
        while (counter != 0)
        {
            Console.Write(new string('.', N / 2 - counter));
            for (int i = 0; i < counter; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("\\");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            if (counter % 2 == 0)
            {
                for (int z = 0; z < counter; z++)
                {
                    if (z % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                }
            }
            else
            {
                for (int t = 0; t < counter; t++)
                {
                    if (t % 2 == 0)
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.Write(new string('.', N / 2 - counter));
            counter--;
            Console.WriteLine();
        }

    }
}


