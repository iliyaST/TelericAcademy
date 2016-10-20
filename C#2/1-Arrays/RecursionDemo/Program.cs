using System;

class Recursion
{
    static void Main()
    {
        //10 - 30000
        int N = int.Parse(Console.ReadLine());

        Console.WriteLine(sum(N));
    }

    private static int sum(int n)
    {
        if (n == 0)
        {
            return 0;
        }
        return n + sum(n - 1);
    }
}