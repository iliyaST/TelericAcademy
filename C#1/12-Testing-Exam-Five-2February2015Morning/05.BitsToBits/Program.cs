using System;
using System.IO;
using System.Numerics;

class BitsToBits
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../BitsToBits.txt");
        Console.SetIn(sr);

        int countOfNumbers = int.Parse(Console.ReadLine());
        string resultSequince = "";
        int counterZeroes = 0;
        int counterOnes = 0;
        int maxZeroes = int.MinValue;
        int maxOnes = int.MinValue;

        for (int i = 0; i < countOfNumbers; i++)
        {
            long temp = long.Parse(Console.ReadLine());
            string sequince = Convert.ToString(temp, 2).PadLeft(30, '0');
            resultSequince += sequince;
        }

        foreach (var ch in resultSequince)
        {
            if (ch == '0')
            {
                if (maxOnes <= counterOnes)
                {
                    maxOnes = counterOnes;
                }
                counterOnes = 0;
                counterZeroes++;
            }
            else if (ch == '1')
            {
                if (maxZeroes <= counterZeroes)
                {
                    maxZeroes = counterZeroes;
                }
                counterZeroes = 0;
                counterOnes++;
            }
        }
        if (maxOnes < counterOnes)
        {
            maxOnes = counterOnes;
        }
        if (maxZeroes < counterZeroes)
        {
            maxZeroes = counterZeroes;
        }
        Console.WriteLine(maxZeroes);
        Console.WriteLine(maxOnes);

    }
}
