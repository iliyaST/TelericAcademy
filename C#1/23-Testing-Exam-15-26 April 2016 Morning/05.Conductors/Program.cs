using System;
using System.IO;

class Conductors
{
    static void Main()
    {
        //StreamReader sr = new StreamReader("../../input.txt");
        // Console.SetIn(sr);

        int P = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        int bitP = 0;
        int counter = 0;
        int len = Convert.ToString(P, 2).Length;
        int bitPos = 0;

        for (int i = 0; i < M; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            int lenM = Convert.ToString(temp, 2).Length;

            for (bitPos = 0; bitPos < lenM; bitPos++)
            {
                if (counter == len)
                {
                    bitP = 0;
                    counter = 0;
                    for (int r = bitPos - len; r < bitPos; r++)
                    {
                        int mask0 = ~(1 << r);
                        temp = temp & mask0;
                    }
                    bitPos = -1;
                }

                int mask = 1 << bitPos;
                int nAndMask = temp & mask;
                int bit = nAndMask >> bitPos;

                int mask1 = 1 << bitP;
                int nAndMask1 = P & mask1;
                int bit1 = nAndMask1 >> bitP;

                //1010101010101001011010100101010
                //0000000000000000010000000000000

                if (bit == bit1)
                {
                    counter++;
                }
                else
                {
                    mask1 = 1 << 0;
                    nAndMask1 = P & mask1;
                    bit1 = nAndMask1 >> 0;

                    if (bit == 1)
                    {
                        if (bit1 == 1)
                        {
                            bitP = 1;
                            counter = 1;
                            continue;
                        }
                        else
                        {
                            bitP = 0;
                            counter = 0;
                            continue;
                        }
                    }
                    else
                    {
                        if (bit1 == 0)
                        {
                            bitP = 1;
                            counter = 1;
                            continue;
                        }
                        else
                        {
                            bitP = 0;
                            counter = 0;
                            continue;
                        }
                    }
                }

                bitP++;
            }
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
            Console.WriteLine(temp);
            bitP = 0;
            counter = 0;
        }
    }
}

