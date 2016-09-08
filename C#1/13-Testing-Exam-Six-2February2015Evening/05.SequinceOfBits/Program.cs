using System;

class SequinceOfBits
{
    static void Main()
    {
        int countOfNumbers = int.Parse(Console.ReadLine());
        long lastBit = 5;
        int currentOnes = 0;
        int currentZeroes = 0;
        int maxOnes = int.MinValue;
        int maxZeroes = int.MinValue;

        for (int i = 0; i < countOfNumbers; i++)
        {
            long temp = long.Parse(Console.ReadLine());

            for (int j = 29; j >= 0; j--)
            {
                int mask = 1 << j;
                long nAndMask = temp & mask;
                long bit = nAndMask >> j;
                if (bit == 1)
                {
                    if (lastBit == 1)
                    {
                        currentOnes++;
                    }
                    else
                    {
                        if (maxZeroes < currentZeroes)
                        {
                            maxZeroes = currentZeroes;
                        }
                        currentOnes++;
                        currentZeroes = 0;
                    }
                }
                if (bit == 0)
                {
                    if (lastBit == 0)
                    {
                        currentZeroes++;
                    }
                    else
                    {
                        if (maxOnes < currentOnes)
                        {
                            maxOnes = currentOnes;
                        }
                        currentOnes = 0;
                        currentZeroes++;
                    }
                }
                lastBit = bit;
            }
        }
        if (maxOnes < currentOnes)
        {
            maxOnes = currentOnes;
        }
        if (maxZeroes < currentZeroes)
        {
            maxZeroes = currentZeroes;
        }
        Console.WriteLine(maxOnes);
        Console.WriteLine(maxZeroes);

    }
}

