using System;

class SeatchInBeats
{
    static void Main()
    {
        int S = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        int newS = 0;
        int counter = 3;
        int occurances = 0;
        //Console.WriteLine(Convert.ToString(newS, 2).PadLeft(4, '0'));
        for (int i = 0; i < 4; i++)
        {
            int mask = 1 << i;
            int nAndMask = S & mask;
            newS |= nAndMask;
        }
         //string a =(Convert.ToString(newS,2).PadLeft(4,'0'));

        for (int i = 0; i < N; i++)
        {
            long temp = long.Parse(Console.ReadLine());
            string a = Convert.ToString(temp, 2).PadLeft(30, '0');
            for (int j = 29; j >= 0; j--)
            {
                counter = 3;
                int counterA = 0;
                for (int x = j; x >= j - 3; x--)
                {
                    int mask = 1 << x;
                    long nAndMask = temp & mask;
                    long bit = nAndMask >> x;

                    int mask1 = 1 << counter;
                    long nAndMask1 = newS & mask1;
                    long bit1 = nAndMask1 >> counter;
                                     
                    if (bit == bit1)
                    {
                        counterA++;                                        
                    }
                    counter--;
                }

                if (counterA == 4)
                {
                    occurances++;
                }
                if (j == 3)
                {
                    break;
                }
            }
        }
         Console.WriteLine(occurances);
    }
}

