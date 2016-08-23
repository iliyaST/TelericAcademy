using System;

class Testing05
{
    static void Main()
    {
        int temp = 240;
        int temp1 = 240;
        int temp2 = 240;
        int countZeroes = 0;

        int colSum = temp | temp1 | temp2;
        
        Console.WriteLine(Convert.ToString(colSum, 2).PadLeft(8, '0'));
        Console.WriteLine(Convert.ToString(temp, 2).PadLeft(8, '0'));
        Console.WriteLine(Convert.ToString(temp1, 2).PadLeft(8, '0'));
        Console.WriteLine(Convert.ToString(temp2, 2).PadLeft(8, '0'));

        for (int i = 0; i < 8; i++)
        {
            if ((colSum & (1 << i)) == 0)
            {
                countZeroes++;
            }
        }
        Console.WriteLine();
        Console.WriteLine(countZeroes);
        //Console.WriteLine(Convert.ToString(temp, 2).PadLeft(8, '0'));
    }
}

