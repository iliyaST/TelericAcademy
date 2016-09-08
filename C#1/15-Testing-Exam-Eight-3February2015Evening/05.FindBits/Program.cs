using System;

class FindBits
{
    static void Main()
    {
        int S = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        var isEqual = false;
        int occurrances = 0;

        for (int i = 0; i < N; i++)
        {
            long temp = long.Parse(Console.ReadLine());
            for (int j = 0; j < 25; j++)
            {
                for (int x = 0; x < 5; x++)
                {
                    int mask = 1 << x + j;
                    long nAndMask = temp & mask;
                    long bit = nAndMask >> x + j;

                    int mask1 = 1 << x;
                    long nAndMask1 = S & mask1;
                    long bit1 = nAndMask1 >> x;

                    if (bit == bit1)
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }               
                if(isEqual == true)
                {
                    occurrances++;
                    isEqual = false;
                }
            }
        }
        Console.WriteLine(occurrances);
    }
}

