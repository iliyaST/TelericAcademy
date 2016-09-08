using System;

class ANacci
{
    static void Main()
    {
        string firstL = Console.ReadLine();
        string secondL = Console.ReadLine();
        int numberL = int.Parse(Console.ReadLine());
        string interval = " ";

        int first = firstL[0] - 64;
        int second = secondL[0] - 64;

        if (numberL == 1)
        {
            Console.WriteLine(firstL);
        }
        else if (numberL == 2)
        {
            Console.WriteLine(firstL);
            if (first + second > 26)
            {
                int temp2 = (first + second + 64)%26;
                Console.WriteLine("{0}{1}", secondL, (char)(temp2 + 64));
            }
            else
            {
                int temp2 = first + second + 64;
                Console.WriteLine("{0}{1}", secondL, (char)(temp2));
            }
        }
        else
        {
            Console.WriteLine(firstL);
            if (first + second > 26)
            {
                int temp2 = ((first + second ) % 26);
                Console.WriteLine("{0}{1}", secondL, (char)(temp2+64));
            }
            else
            {
                Console.WriteLine("{0}{1}", secondL, (char)((first + second + 64)));
            }
            int temp1 = first;
            first = second;
            second = temp1 + second;
            for (int i = 3; i <= numberL; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    int temp = first + second;
                    first = second;
                    if (temp > 26)
                    {
                        temp %= 26;
                    }
                    second = temp;
                    
                    if (j == 2)
                    {
                        Console.Write((char)(temp + 64));
                        continue;
                    }
                    Console.Write((char)(temp + 64) + interval);
                    interval += " ";
                }
                Console.WriteLine();
            }
        }
    }
}

