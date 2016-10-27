using System;

class Recursion
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        for (int i = 0; i < k; i++)
        {
            long mask = 1 << p + i;
            long nAndMask = number & mask;
            long bit = nAndMask >> p + i;

            long mask1 = 1 << q + i;
            long nAndMask1 = number & mask1;
            long bit1 = nAndMask1 >> q + i;

            if (bit != bit1)
            {
                if (bit == 0)
                {
                    // set small bit
                    long mask2 = 1 << p + i;
                    number = number | mask2;
                    // set big bit
                    long mask4 = ~(1 << q + i );
                    number = number & mask4;
                }
                if (bit == 1)
                {
                    // set small bit
                    long mask3 = ~(1 << p + i);
                    number = number & mask3;
                    // set big bit
                    long mask5 = 1 << q + i ;
                    number = number | mask5;
                }
            }
        }
        Console.WriteLine(number);
    }
}



