using System;
using System.IO;
using System.Numerics;

class NaBabaMiSmetalnika
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        BigInteger row0 = long.Parse(Console.ReadLine());
        BigInteger row1 = long.Parse(Console.ReadLine());
        BigInteger row2 = long.Parse(Console.ReadLine());
        BigInteger row3 = long.Parse(Console.ReadLine());
        BigInteger row4 = long.Parse(Console.ReadLine());
        BigInteger row5 = long.Parse(Console.ReadLine());
        BigInteger row6 = long.Parse(Console.ReadLine());
        BigInteger row7 = long.Parse(Console.ReadLine());
        int row, col;
        BigInteger mask;
        int counter = 0;
        int counterA = 0;
        int counterB = 0;
        BigInteger finalScore = 0;
        int countZeroes = 0;
        BigInteger zeroesSum = 0;

        while (true)
        {
            finalScore = row0 + row1 + row2 + row3 + row4 + row5 + row6 + row7;
            string tempCommand = Console.ReadLine();
            if (tempCommand == "stop")
            {
                zeroesSum = row0 | row1 | row2 | row3 | row4 | row5 | row6 | row7;
                for (int i = 0; i < width; i++)
                {
                    if ((zeroesSum & (1 << i)) == 0)
                    {
                        countZeroes++;
                    }
                }
                if (countZeroes > 0)
                {
                    Console.WriteLine(finalScore * countZeroes);
                }
                else
                {
                    Console.WriteLine(finalScore);
                }
                break;
            }
            if (tempCommand == "right")
            {
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());
                BigInteger temp = 0;
                if (col < 0)
                {
                    col = 0;
                }
                if(col>0)
                {
                    col = width - 1;
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
                    BigInteger nAndMask = temp & mask;
                    BigInteger bit = nAndMask >> i;
                    if (bit == 1)
                    {
                        mask = ~(1 << i);
                        BigInteger result = temp & mask;
                        temp = temp & result;
                        counter++;
                    }
                }
                for (int i = 0; i < counter; i++)
                {
                    mask = 1 << i;
                    BigInteger result = temp | mask;
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
                BigInteger temp = 0;
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
                    for (int j = 0; j < width; j++)
                    {
                        mask = 1 << j;
                        BigInteger nAndMask = temp & mask;
                        BigInteger bit = nAndMask >> j;
                        if (bit == 1)
                        {
                            counterA++;
                        }
                    }
                    temp = 0;
                    for (int x = width; x >= width - counterA; x--)
                    {
                        mask = 1 << x;
                        BigInteger result = temp | mask;
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
                BigInteger temp = 0; ;
                if (col < 0)
                {
                    col = 0;
                }
                if(col>0)
                {
                    col = col - 1;
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
                for (int i = width - 1; i >= (width - 1) - col; i--)
                {
                    mask = 1 << i;
                    BigInteger nAndMask = temp & mask;
                    BigInteger bit = nAndMask >> i;
                    if (bit == 1)
                    {
                        mask =~(1 << i);
                        BigInteger result = temp & mask;
                        temp = temp & result;
                        counterB++;
                    }
                }
                for (int i = width - 1; i > (width - 1) - counterB; i--)
                {
                    mask = 1 << i;
                    BigInteger result = temp | mask;
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
        }
        //Console.WriteLine(Convert.ToString(row0, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row1, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row2, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row3, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row4, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row5, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row6, 2).PadLeft(8, '0'));
        //Console.WriteLine(Convert.ToString(row7, 2).PadLeft(8, '0'));

    }
}


