using System;

class Problem248
{
    static void Main()
    {
        long A = long.Parse(Console.ReadLine());
        long B = long.Parse(Console.ReadLine());
        long C = long.Parse(Console.ReadLine());
        long R = 0;
        long result = 0;

        if (B==2)
        {
            R = A % C;
        }
        if (B==4)
        {
            R = A + C;
        }
        if (B==8)
        {
            R = A * C;
        }

        if(R%4==0)
        {
            result = R / 4;
        }
        else
        {
            result = R % 4;
        }

        Console.WriteLine(result);
        Console.WriteLine(R);
    }
}

