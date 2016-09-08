using System;

class PersianRugs
{
    static void Main()
    {
        //height = width = 2 * N + 1\
        int n = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int height = 2 * n + 1;
        int width = height;
        int counter = 0;
        int dotCounter = 0;
        bool dotIsOne = false;

        if (d >= n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('#', 0 + i));
                Console.Write(new string('\\', 1));
                Console.Write(new string(' ', 2 * n - 1 - counter));
                Console.Write(new string('/', 1));
                Console.WriteLine(new string('#', 0 + i));
                counter += 2;
            }
            counter = 0;
            Console.Write(new string('#', n));
            Console.Write(new string('X', 1));
            Console.WriteLine(new string('#', n));
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('#', n - 1 - i));
                Console.Write(new string('/', 1));
                Console.Write(new string(' ', 1 + counter));
                Console.Write(new string('\\', 1));
                Console.WriteLine(new string('#', n - 1 - i));
                counter += 2;
            }
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                if (dotIsOne == true)
                {
                    Console.Write(new string('#', 0 + i));
                    Console.Write(new string('\\', 1));
                    Console.Write(new string(' ', ((2 * n + 1) - ((i + 1) * 2))));
                    Console.Write(new string('/', 1));
                    Console.WriteLine(new string('#', 0 + i));
                    continue;
                }
                Console.Write(new string('#', 0 + i));
                Console.Write(new string('\\', 1));
                Console.Write(new string(' ', d));
                Console.Write(new string('\\', 1));
                Console.Write(new string('.', (n * 2 - 3) - (d * 2) - dotCounter));
                Console.Write(new string('/', 1));
                Console.Write(new string(' ', d));
                Console.Write(new string('/', 1));
                Console.WriteLine(new string('#', 0 + i));
                if (((n * 2 - 3) - (d * 2) - dotCounter) == 1)
                {
                    dotIsOne = true;
                    continue;
                }
                dotCounter += 2;
            }
            dotCounter = 0;
            Console.Write(new string('#', n));
            Console.Write(new string('X', 1));
            Console.WriteLine(new string('#', n));
            dotIsOne = false;
            //TOPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP

            for (int i = n - 1; i >= 0; i--)
            {
                if (((2 * n + 1) - (i * 2) - (2 * d) - 4) == 1)
                {
                    dotIsOne = true;
                }
                if (dotIsOne == true)
                {
                    Console.Write(new string('#', 0 + i));
                    Console.Write(new string('/', 1));
                    Console.Write(new string(' ', d));
                    Console.Write(new string('/', 1));
                    Console.Write(new string('.', ((2 * n + 1) - (i * 2) - (2 * d) - 4)));
                    Console.Write(new string('\\', 1));
                    Console.Write(new string(' ', d));
                    Console.Write(new string('\\', 1));
                    Console.WriteLine(new string('#', 0 + i));                 
                    continue;
                }
                Console.Write(new string('#', 0 + i));
                Console.Write(new string('/', 1));
                Console.Write(new string(' ', 1 + counter));
                Console.Write(new string('\\', 1));
                Console.WriteLine(new string('#', 0 + i));
                counter += 2;
            }
        }

    }
}

