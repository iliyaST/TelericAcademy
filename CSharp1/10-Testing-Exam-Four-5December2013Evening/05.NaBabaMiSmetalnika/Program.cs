using System;
using System.IO;

class NaBabaMiSmetalnika
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        long row0 = long.Parse(Console.ReadLine());
        long row1 = long.Parse(Console.ReadLine());
        long row2 = long.Parse(Console.ReadLine());
        long row3 = long.Parse(Console.ReadLine());
        long row4 = long.Parse(Console.ReadLine());
        long row5 = long.Parse(Console.ReadLine());
        long row6 = long.Parse(Console.ReadLine());
        long row7 = long.Parse(Console.ReadLine());
        int row, col, mask;
        int counter = 0;
        int counterA = 0;
        int counterB = 0;

        while (true)
        {
            string tempCommand = Console.ReadLine();
            if (tempCommand == "stop")
            {
                break;
            }
            if (tempCommand == "right")
            {
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());
                long temp = 0; ;
                if (col < 0)
                {
                    col = 0;
                }
                switch (row)
                {
                    case 0: temp = row0; break;
                    case 1: temp = row1; break;
                    case 2: temp = row2; break;
                    case 3: temp = row3; break;
                    case 4: temp = row4; break;
                    case 5: temp = row5; break;
                    case 6: temp = row6; break;
                    case 7: temp = row7; break;
                }
                for (int i = 0; i < width - col; i++)
                {
                    mask = 1 << i;
                    long nAndMask = temp & mask;
                    long bit = nAndMask >> i;
                    if (bit == 1)
                    {
                        mask = ~(1 << i);
                        long result = temp & mask;
                        temp = temp & result;
                        counter++;
                    }
                }
                for (int i = 0; i < counter; i++)
                {
                    mask = 1 << i;
                    long result = temp | mask;
                    temp = temp | result;
                }
                switch (row)
                {
                    case 0: row0 = temp; break;
                    case 1: row1 = temp; break;
                    case 2: row2 = temp; break;
                    case 3: row3 = temp; break;
                    case 4: row4 = temp; break;
                    case 5: row5 = temp; break;
                    case 6: row6 = temp; break;
                    case 7: row7 = temp; break;
                }
            }
            counter = 0;
            if (tempCommand == "reset")
            {
                long temp = 0;
                for (int i = 0; i < 8; i++)
                {
                    switch (i)
                    {
                        case 0: temp = row0; break;
                        case 1: temp = row1; break;
                        case 2: temp = row2; break;
                        case 3: temp = row3; break;
                        case 4: temp = row4; break;
                        case 5: temp = row5; break;
                        case 6: temp = row6; break;
                        case 7: temp = row7; break;
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        mask = 1 << j;
                        long nAndMask = temp & mask;
                        long bit = nAndMask >> j;
                        if (bit == 1)
                        {
                            counterA++;
                        }
                    }
                    temp = 0;
                    for (int x = 7; x >= counterA; x--)
                    {
                        mask = 1 << x;
                        long result = temp | mask;
                        temp = temp | result;
                    }
                    counterA = 0;
                    switch (i)
                    {
                        case 0: row0 = temp; break;
                        case 1: row1 = temp; break;
                        case 2: row2 = temp; break;
                        case 3: row3 = temp; break;
                        case 4: row4 = temp; break;
                        case 5: row5 = temp; break;
                        case 6: row6 = temp; break;
                        case 7: row7 = temp; break;
                    }
                }
            }
            if (tempCommand == "left")
            {
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());
                long temp = 0; ;
                if (col < 0)
                {
                    col = 0;
                }
                switch (row)
                {
                    case 0: temp = row0; break;
                    case 1: temp = row1; break;
                    case 2: temp = row2; break;
                    case 3: temp = row3; break;
                    case 4: temp = row4; break;
                    case 5: temp = row5; break;
                    case 6: temp = row6; break;
                    case 7: temp = row7; break;
                }
                for (int i = 7; i >= 7 - col; i--)
                {
                    mask = 1 << i;
                    long nAndMask = temp & mask;
                    long bit = nAndMask >> i;
                    if (bit == 1)
                    {
                        mask = ~(1 << i);
                        long result = temp & mask;
                        temp = temp & result;
                        counterB++;                       
                    }
                }             
                for (int i = 7; i > 7 - counterB; i--)
                {
                    mask = 1 << i;
                    long result = temp | mask;
                    temp = temp | result;                 
                }
                counterB = 0;
                switch (row)
                {
                    case 0: row0 = temp; break;
                    case 1: row1 = temp; break;
                    case 2: row2 = temp; break;
                    case 3: row3 = temp; break;
                    case 4: row4 = temp; break;
                    case 5: row5 = temp; break;
                    case 6: row6 = temp; break;
                    case 7: row7 = temp; break;
                }
            }
            Console.WriteLine(Convert.ToString(row0, 2).PadLeft(8, '0'));
            Console.WriteLine(Convert.ToString(row1, 2).PadLeft(8, '0'));
            Console.WriteLine(Convert.ToString(row2, 2).PadLeft(8, '0'));
            Console.WriteLine(Convert.ToString(row3, 2).PadLeft(8, '0'));
            Console.WriteLine(Convert.ToString(row4, 2).PadLeft(8, '0'));
            Console.WriteLine(Convert.ToString(row5, 2).PadLeft(8, '0'));
            Console.WriteLine(Convert.ToString(row6, 2).PadLeft(8, '0'));
            Console.WriteLine(Convert.ToString(row7, 2).PadLeft(8, '0'));

        }
    }
}

