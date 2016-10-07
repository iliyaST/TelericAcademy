using System;

class BobbyAvokadoto
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());
        int maxComb = 0;
        string nS = Convert.ToString(N, 2);
        int lenN = nS.Length;
        int maxValue = 0;
        bool isOverlapp = false;

        for (int i = 0; i < C; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            string tempS = Convert.ToString(temp, 2);
            int len = tempS.Length;
            int counter = 0;

            for (int bitPs = 0; bitPs < lenN; bitPs++)
            {
                int bitTemp = 0;
                int bitP = bitPs;

                while (bitP < bitPs + len)
                {
                    int mask = 1 << bitP;
                    int nAndMask = N & mask;
                    int bit = nAndMask >> bitP;

                    int mask1 = 1 << bitTemp;
                    int nAndMask1 = temp & mask1;
                    int bit1 = nAndMask1 >> bitTemp;

                    if (bit == bit1)
                    {
                        isOverlapp = true;
                        break;
                    }
                    else
                    {
                        counter++;
                    }

                    bitP++;
                    bitTemp++;
                }
                if (maxComb < counter)
                {
                    maxComb = counter;
                    maxValue = temp;
                }
                if (counter == len || isOverlapp == true)
                {
                    break;
                }
                bitTemp = 0;
            }
        }
        Console.WriteLine(maxValue);
    }
}

