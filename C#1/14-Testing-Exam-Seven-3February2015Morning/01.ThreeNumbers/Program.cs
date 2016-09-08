using System;

class ThreeNumbers
{
    static void Main()
    {
        long max = long.MinValue;
        long min = long.MaxValue;
        long aritmeticValue = 0;

        for (int i = 0; i < 3; i++)
        {
            long temp = long.Parse(Console.ReadLine());
            aritmeticValue += temp;
            if (max < temp)
            {
                max = temp;
            }
            if (min > temp)
            {
                min = temp;
            }
        }
        Console.WriteLine(max);
        Console.WriteLine(min);
        Console.WriteLine("{0:F2}", (decimal)aritmeticValue / 3);
    }
}

