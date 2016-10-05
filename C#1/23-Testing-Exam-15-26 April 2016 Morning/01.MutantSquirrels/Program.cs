using System;

class MutantSquirrels
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine());
        int B = int.Parse(Console.ReadLine());
        int S = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        double tails = 0;

        long totalTails = T;
        totalTails *= B;
        totalTails *= S;
        totalTails *= N;

        if (totalTails % 2 == 0)
        {
             tails = totalTails * 376439.0;
        }
        else
        {
             tails = totalTails / 7.0;
        }

        Console.WriteLine("{0:F3}", tails);
    }
}

