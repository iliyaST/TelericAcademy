using System;

class BitBall
{
    static void Main()
    {
        int rowTop0 = int.Parse(Console.ReadLine());
        int rowTop1 = int.Parse(Console.ReadLine());
        int rowTop2 = int.Parse(Console.ReadLine());
        int rowTop3 = int.Parse(Console.ReadLine());
        int rowTop4 = int.Parse(Console.ReadLine());
        int rowTop5 = int.Parse(Console.ReadLine());
        int rowTop6 = int.Parse(Console.ReadLine());
        int rowTop7 = int.Parse(Console.ReadLine());
        int rowBottom0 = int.Parse(Console.ReadLine());
        int rowBottom1 = int.Parse(Console.ReadLine());
        int rowBottom2 = int.Parse(Console.ReadLine());
        int rowBottom3 = int.Parse(Console.ReadLine());
        int rowBottom4 = int.Parse(Console.ReadLine());
        int rowBottom5 = int.Parse(Console.ReadLine());
        int rowBottom6 = int.Parse(Console.ReadLine());
        int rowBottom7 = int.Parse(Console.ReadLine());


        int tempT = 0;
        int tempB = 0;
        int tempTB = 0;

        int row0 = 0;
        int row1 = 0;
        int row2 = 0;
        int row3 = 0;
        int row4 = 0;
        int row5 = 0;
        int row6 = 0;
        int row7 = 0;

        bool isEmpty = true;
        int counterT = 0;
        int counterB = 0;

        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 0: tempT = rowTop0; tempB = rowBottom0; break;
                case 1: tempT = rowTop1; tempB = rowBottom1; break;
                case 2: tempT = rowTop2; tempB = rowBottom2; break;
                case 3: tempT = rowTop3; tempB = rowBottom3; break;
                case 4: tempT = rowTop4; tempB = rowBottom4; break;
                case 5: tempT = rowTop5; tempB = rowBottom5; break;
                case 6: tempT = rowTop6; tempB = rowBottom6; break;
                case 7: tempT = rowTop7; tempB = rowBottom7; break;
            }
            for (int j = 0; j < 8; j++)
            {
                int mask = 1 << j;
                int nAndMask = tempT & mask;
                int bit = nAndMask >> j;

                int mask1 = 1 << j;
                int nAndMask1 = tempB & mask1;
                int bit1 = nAndMask1 >> j;

                if (bit == bit1)
                {
                    mask = ~(1 << j);
                    tempT = tempT & mask;
                    mask1 = ~(1 << j);
                    tempB = tempB & mask;
                }
            }
            switch (i)
            {
                case 0: rowTop0 = tempT; rowBottom0 = tempB; row0 = tempT | tempB; break;
                case 1: rowTop1 = tempT; rowBottom1 = tempB; row1 = tempT | tempB; break;
                case 2: rowTop2 = tempT; rowBottom2 = tempB; row2 = tempT | tempB; break;
                case 3: rowTop3 = tempT; rowBottom3 = tempB; row3 = tempT | tempB; break;
                case 4: rowTop4 = tempT; rowBottom4 = tempB; row4 = tempT | tempB; break;
                case 5: rowTop5 = tempT; rowBottom5 = tempB; row5 = tempT | tempB; break;
                case 6: rowTop6 = tempT; rowBottom6 = tempB; row6 = tempT | tempB; break;
                case 7: rowTop7 = tempT; rowBottom7 = tempB; row7 = tempT | tempB; break;
            }
        }
        //Console.WriteLine("ROWTOP");
        //Console.WriteLine(Convert.ToString(rowTop0, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(rowTop1, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(rowTop2, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(rowTop3, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(rowTop4, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(rowTop5, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(rowTop6, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(rowTop7, 2).PadLeft(8, '0'));
        //Console.WriteLine("ROWTOP");
        //Console.WriteLine("FINALLLL");
        //Console.WriteLine(Convert.ToString(row0,2).PadLeft(8,'0'));
        //Console.WriteLine(Convert.ToString(row1, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row2, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row3, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row4, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row5, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row6, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row7, 2).PadLeft(8, '0'));
        //Console.WriteLine("FINALL>>>>");


        //TOP score
        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 0: tempT = rowTop0; tempB = rowBottom0; break;
                case 1: tempT = rowTop1; tempB = rowBottom1; break;
                case 2: tempT = rowTop2; tempB = rowBottom2; break;
                case 3: tempT = rowTop3; tempB = rowBottom3; break;
                case 4: tempT = rowTop4; tempB = rowBottom4; break;
                case 5: tempT = rowTop5; tempB = rowBottom5; break;
                case 6: tempT = rowTop6; tempB = rowBottom6; break;
                case 7: tempT = rowTop7; tempB = rowBottom7; break;
            }

            for (int j = 0; j < 8; j++)
            {
                int mask = 1 << j;
                int nAndMask = tempT & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    for (int x = i + 1; x < 8; x++)
                    {
                        switch (x)
                        {
                            case 0: tempTB = row0; break;
                            case 1: tempTB = row1; break;
                            case 2: tempTB = row2; break;
                            case 3: tempTB = row3; break;
                            case 4: tempTB = row4; break;
                            case 5: tempTB = row5; break;
                            case 6: tempTB = row6; break;
                            case 7: tempTB = row7; break;
                        }
                        int mask1 = 1 << j;
                        int nAndMask1 = tempTB & mask1;
                        int bit1 = nAndMask1 >> j;
                        if (bit1 == 1)
                        {
                            isEmpty = false;
                            break;
                        }
                    }
                    if (isEmpty == true)
                    {
                        counterT++;
                    }
                    else
                    {
                        isEmpty = true;
                    }
                }
            }
        }
        //Bottom Score
        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 0: tempB = rowBottom0; break;
                case 1: tempB = rowBottom1; break;
                case 2: tempB = rowBottom2; break;
                case 3: tempB = rowBottom3; break;
                case 4: tempB = rowBottom4; break;
                case 5: tempB = rowBottom5; break;
                case 6: tempB = rowBottom6; break;
                case 7: tempB = rowBottom7; break;
            }

            for (int j = 0; j < 8; j++)
            {
                int mask = 1 << j;
                int nAndMask = tempB & mask;
                int bit = nAndMask >> j;
                if (bit == 1 && i == 0)
                {
                    counterB++;
                }
                else
                {
                    if (bit == 1)
                    {
                        for (int x = i - 1; x >= 0; x--)
                        {
                            switch (x)
                            {
                                case 0: tempTB = row0; break;                            
                                case 1: tempTB = row1; break;
                                case 2: tempTB = row2; break;
                                case 3: tempTB = row3; break;
                                case 4: tempTB = row4; break;
                                case 5: tempTB = row5; break;
                                case 6: tempTB = row6; break;
                                case 7: tempTB = row7; break;                               
                            }
                            int mask1 = 1 << j;
                            int nAndMask1 = tempTB & mask1;
                            int bit1 = nAndMask1 >> j;
                            if (bit1 == 1)
                            {
                                isEmpty = false;
                                break;
                            }
                        }
                        if (isEmpty == true)
                        {
                            counterB++;
                        }
                        else
                        {
                            isEmpty = true;
                        }
                    }
                }
            }
        }
        Console.Write(counterT + ":");
        Console.WriteLine(counterB);
    }
}
