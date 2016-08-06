using System;


class Encrypt369
{
    static void Main()
    {
        long positiveIntegerA = long.Parse(Console.ReadLine());
        long positiveIntegerB = long.Parse(Console.ReadLine());
        long positiveIntegerC = long.Parse(Console.ReadLine());

        long R = 0;
        long result = 0;

        if (positiveIntegerB == 3)
        {
            R = positiveIntegerA + positiveIntegerC;
        }
        if (positiveIntegerB == 6)
        {
            R = positiveIntegerA * positiveIntegerC;
        }
        if (positiveIntegerB == 9)
        {
            R = positiveIntegerA % positiveIntegerC;
        }


        if (R % 3 == 0)
        {
            result = R / 3;
        }
        else
        {
            result = R % 3;
        }
        Console.WriteLine(result);
        Console.WriteLine(R);

    }
}


