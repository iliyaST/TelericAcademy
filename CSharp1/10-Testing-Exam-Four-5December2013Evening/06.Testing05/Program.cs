using System;

class Testing05
{
    static void Main()
    {
        int temp = 0;
        for (int i = 8; i > 4; i--)
        {
            int mask = 1 << i;
            int result = temp | mask;
           // Console.WriteLine(Convert.ToString(result, 2).PadLeft(8, '0'));
            temp = temp | result;
        }
        Console.WriteLine(Convert.ToString(temp, 2).PadLeft(8, '0'));
    }
}

