using System;
using System.IO;
using System.Numerics;

class DancingBits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        int kSeq = 0;
        int len = 0;
        int lastBit = -1;
        //00101 110 1110 1000111

        for (int i = 0; i < N; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            bool isOne = false;            
            for (int bitPosition = 31; bitPosition >= 0; bitPosition--)
            {
                int mask = 1 << bitPosition;
                int nAndMask = temp & mask;
                int currentbit = nAndMask >> bitPosition;
                if (currentbit == 1)
                {
                    isOne = true;
                }
                if (isOne)
                {
                    if (lastBit == currentbit)
                    {
                        len++;
                    }
                    else
                    {
                        if (len == k)
                        {
                            kSeq++;
                        }
                        len = 1;
                    }
                    lastBit = currentbit;
                }
            }           
        }
        if (len == k)
        {
            kSeq++;
        }
        Console.WriteLine(kSeq);
    }
}

