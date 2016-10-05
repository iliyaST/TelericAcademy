using System;

class BitsToBits
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int lastBit = -1;
        int maxZeroes = 0;
        int maxOnes = 0;
        int counterOnes = 0;
        int counterZeroes = 0;


        for (int i = 0; i < N; i++)
        {
            int temp = int.Parse(Console.ReadLine());

            for (int j = 29; j >= 0; j--)
            {
                int mask = 1 << j;
                int nAndMask = temp & mask;
                int bit = nAndMask >> j;

                if (bit == 1)
                {
                    if (counterZeroes > maxZeroes)
                    {
                        maxZeroes = counterZeroes;
                    }
                    counterZeroes = 0;
                    counterOnes++;
                }
                else if (bit == 0)
                {
                    if (counterOnes > maxOnes)
                    {
                        maxOnes = counterOnes;
                    }
                    counterOnes = 0;
                    counterZeroes++;
                }
            }
        }

        if (counterOnes > maxOnes)
        {
            maxOnes = counterOnes;
        }
        if (counterZeroes > maxZeroes)
        {
            maxZeroes = counterZeroes;
        }

        Console.WriteLine(maxZeroes);
        Console.WriteLine(maxOnes);
    }
}

