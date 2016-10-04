using System;

class MathExpression
{
    static void Main()
    {
        decimal N = decimal.Parse(Console.ReadLine());
        decimal M = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());
        decimal result = 0;
        decimal num = 0;
        decimal den = 0;
        decimal fraction = 0;
        decimal mod = 0;

        //numinator
        num = (N * N) + (1 / (M * P)) + 1337;
        //denuminator
        den = N - (128.523123123m * P);

        fraction = num / den;

        mod = (decimal)Math.Sin((int)M % 180);

        result = (fraction + mod);

        Console.WriteLine("{0:F6}", result);
    }
}

