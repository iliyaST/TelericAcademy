using System;

class FallDown
{
    static void Main()
    {
        int row0 = int.Parse(Console.ReadLine());
        int row1 = int.Parse(Console.ReadLine());
        int row2 = int.Parse(Console.ReadLine());
        int row3 = int.Parse(Console.ReadLine());
        int row4 = int.Parse(Console.ReadLine());
        int row5 = int.Parse(Console.ReadLine());
        int row6 = int.Parse(Console.ReadLine());
        int row7 = int.Parse(Console.ReadLine());
        int lowerRow = 0;

        //Console.WriteLine(Convert.ToString(row0, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row1, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row2, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row3, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row4, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row5, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row6, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row7, 2).PadLeft(8, '0'));

        for (int h = 0; h < 8; h++)
        {
            for (int i = 6; i >= 0; i--)
            {
                int temp = 0;
                int temp1 = 0;

                switch (i)
                {
                    case 6: temp = row6; temp1 = row7; break;
                    case 5: temp = row5; temp1 = row6; break;
                    case 4: temp = row4; temp1 = row5; break;
                    case 3: temp = row3; temp1 = row4; break;
                    case 2: temp = row2; temp1 = row3; break;
                    case 1: temp = row1; temp1 = row2; break;
                    case 0: temp = row0; temp1 = row1; break;
                }
                for (int j = 0; j < 8; j++)
                {
                    int mask = 1 << j;
                    int nAndMask = temp & mask;
                    int bit = nAndMask >> j;
                    if (bit == 1)
                    {
                        int mask1 = 1 << j;
                        int nAndMask1 = temp1 & mask1;
                        int bit1 = nAndMask1 >> j;
                        if (bit1 == 0)
                        {
                            int mask0 = ~(1 << j);
                            int result0 = temp & mask0;
                            temp = temp & result0;

                            temp1 = temp1 | mask;
                        }
                    }
                }
                switch (i)
                {
                    case 6: row6 = temp; row7 = temp1; break;
                    case 5: row5 = temp; row6 = temp1; break;
                    case 4: row4 = temp; row5 = temp1; break;
                    case 3: row3 = temp; row4 = temp1; break;
                    case 2: row2 = temp; row3 = temp1; break;
                    case 1: row1 = temp; row2 = temp1; break;
                    case 0: row0 = temp; row1 = temp1; break;
                }
            }
        }
        //Console.WriteLine();
        //Console.WriteLine("........................................");
        //Console.WriteLine();
        //Console.WriteLine(Convert.ToString(row0, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row1, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row2, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row3, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row4, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row5, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row6, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row7, 2).PadLeft(8, '0'));
        Console.WriteLine(row0);
        Console.WriteLine(row1);
        Console.WriteLine(row2);
        Console.WriteLine(row3);
        Console.WriteLine(row4);
        Console.WriteLine(row5);
        Console.WriteLine(row6);
        Console.WriteLine(row7);
    }
}

