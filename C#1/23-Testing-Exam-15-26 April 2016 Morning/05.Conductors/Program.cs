using System;

class Conductors
{
    static void Main()
    {
        int P = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        int bitP = 0;
        int counter = 0;
        int len = Convert.ToString(P, 2).Length;
        int bitPos1 = -1;      

        for (int i = 0; i < M; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            int lenM = Convert.ToString(temp, 2).Length;

            for (int bitPos = 0; bitPos < lenM; bitPos++)
            {
                bitPos1++;
                if (counter == len)
                {
                    bitP = 0;
                    counter = 0;
                    for (int r = bitPos - len; r < bitPos; r++)
                    {
                        int mask0 = ~(1 << r);
                        temp = temp & mask0;
                    }
                }

                int mask = 1 << bitPos;
                int nAndMask = temp & mask;
                int bit = nAndMask >> bitPos;

                int mask1 = 1 << bitP;
                int nAndMask1 = P & mask1;
                int bit1 = nAndMask1 >> bitP;

                //1010
                //10 
                if (bit == bit1)
                {
                    counter++;
                }
                else
                {
                    bitP = 0;
                    counter = 0;
                    continue;
                }

                bitP++;
            }
            if (counter == len)
            {
                bitP = 0;
                counter = 0;
                for (int r = bitPos1 - len; r < bitPos1; r++)
                {
                    int mask0 = ~(1 << r);
                    temp = temp & mask0;
                }
            }
            Console.WriteLine(temp);
        }
    }
}

