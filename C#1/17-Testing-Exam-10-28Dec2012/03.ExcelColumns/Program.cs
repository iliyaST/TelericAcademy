using System;
using System.Numerics;
class ExcelColumns
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int count = N-1;

        BigInteger result = 0;

        for (int i = 0; i < N; i++)
        {
            string letter = Console.ReadLine();
            int temp = letter[0];
            temp -= 64;
            //Console.WriteLine(temp);
            result += temp * (long)(Math.Pow(26, count));
            count--;
        }
        Console.WriteLine(result);
    }
}

