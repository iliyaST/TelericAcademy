using System;

class NeuronsBitVersion
{
    static void Main()
    {
        while (true)
        {
            long line = long.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(line, 2).PadLeft(32, '0'));
            if (line == -1)
            {
                break;
            }
            int mostRightBit = -1;
            int mostLeftBit = -2;
            for (int p = 0; p < 32; p++)
            {
                int mask = 1 << p;
                long nAndMask = line & mask;
                long bit = nAndMask >> p;

                if (bit == 1)
                {
                    if (mostRightBit == -1)
                    {
                        mostRightBit = p;
                    }
                    mostLeftBit = p;
                }
            }
            Console.WriteLine("left {0} - right {1}",mostLeftBit,mostRightBit);
            long result = 0;
            for (int p = mostRightBit; p <= mostLeftBit; p++)
            {
                long mask = 1 << p;
                long nAndMask = line & mask;
                long bit = nAndMask >> p;
                Console.WriteLine(Convert.ToString(nAndMask, 2).PadLeft(32, '0'));
                if (bit == 0)
                {
                    result = result | mask;
                }
            }
            Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
        }
    }
}

