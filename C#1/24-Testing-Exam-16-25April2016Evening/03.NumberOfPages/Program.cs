using System;

class NumberOfPages
{
    static void Main()
    {
        int D = int.Parse(Console.ReadLine());
        int digits = 0;
        int pages = 0;

        while (true)
        {
            if (digits == D)
            {
                break;
            }
            pages++;
            if (pages > 9)
            {
                int temp = pages;
                int counter = 0;
                while (temp != 0)
                {
                    counter++;
                    temp /= 10;
                }
                digits += counter;
                continue;
            }
            digits++;            
        }

        Console.WriteLine(pages);
    }
}

