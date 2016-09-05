using System;

class AngryBits
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
        int curRow = 0;
        int curCol = 0;
        int posCounter = 0;
        int topRow = 0;
        int bottomRow = 0;
        int totalResult = 0;
        int pigsKilled = 0;
        bool isPig = false;
        bool isEnd = false;
        int currentResult = 0;
        int currentRow = 0;
        bool isUp = false;
        bool is15 = false;
        //Console.WriteLine(Convert.ToString(row0, 2).PadLeft(16, '0'));
        //Console.WriteLine(Convert.ToString(row1, 2).PadLeft(16, '0'));
        //Console.WriteLine(Convert.ToString(row2, 2).PadLeft(16, '0'));
        //Console.WriteLine(Convert.ToString(row3, 2).PadLeft(16, '0'));
        //Console.WriteLine(Convert.ToString(row4, 2).PadLeft(16, '0'));
        //Console.WriteLine(Convert.ToString(row5, 2).PadLeft(16, '0'));
        //Console.WriteLine(Convert.ToString(row6, 2).PadLeft(16, '0'));
        //Console.WriteLine(Convert.ToString(row7, 2).PadLeft(16, '0'));
        //Console.WriteLine(".........................................");
        for (int i = 8; i < 16; i++)
        {   
            isUp = true;
            for (int j = 0; j < 8; j++)
            {
                curCol = i;
                switch (j)
                {
                    case 0: curRow = row0; break;
                    case 1: curRow = row1; break;
                    case 2: curRow = row2; break;
                    case 3: curRow = row3; break;
                    case 4: curRow = row4; break;
                    case 5: curRow = row5; break;
                    case 6: curRow = row6; break;
                    case 7: curRow = row7; break;
                }
                int mask = 1 << curCol;
                int nAndMask = curRow & mask;
                int bit = nAndMask >> curCol;
                #region IF BIT = 1
                if (bit == 1)
                {
                    currentRow = j;
                    mask = ~(1 << curCol);
                    curRow = curRow & mask;
                    //making the bit zero
                    switch (j)
                    {
                        case 0: row0 = curRow; break;
                        case 1: row1 = curRow; break;
                        case 2: row2 = curRow; break;
                        case 3: row3 = curRow; break;
                        case 4: row4 = curRow; break;
                        case 5: row5 = curRow; break;
                        case 6: row6 = curRow; break;
                        case 7: row7 = curRow; break;
                    }
                    for (int x = 0; x < 16 - j; x++)
                    {
                        if (isEnd == true)
                        {
                            totalResult += currentResult;
                            currentResult = posCounter * pigsKilled;
                            isEnd = false;
                            break;
                        }
                        if (isPig == true)
                        {
                            currentResult = posCounter * pigsKilled;
                            totalResult += currentResult;
                            isPig = false;
                            break;
                        }
                        curCol--;
                        if (currentRow > 0 && isUp == false)
                        {
                            currentRow--;
                            switch (currentRow)
                            {
                                case 0: curRow = row0; bottomRow = row1; break;
                                case 1: curRow = row1; topRow = row0; bottomRow = row2; break;
                                case 2: curRow = row2; topRow = row1; bottomRow = row3; break;
                                case 3: curRow = row3; topRow = row2; bottomRow = row4; break;
                                case 4: curRow = row4; topRow = row3; bottomRow = row5; break;
                                case 5: curRow = row5; topRow = row4; bottomRow = row6; break;
                                case 6: curRow = row6; topRow = row5; bottomRow = row7; break;
                                case 7: curRow = row7; topRow = row6; break;
                            }
                            posCounter++;
                            int mask1 = 1 << curCol;
                            int nAndMask1 = curRow & mask1;
                            int bit1 = nAndMask1 >> curCol;
                            if (bit1 == 1)
                            {
                                for (int z = curCol - 1; z < 3; z++)
                                {
                                    int mask2 = 1 << curCol;
                                    int nAndMask2 = topRow & mask2;
                                    int bit2 = nAndMask2 >> curCol;
                                    if (bit2 == 1)
                                    {
                                        pigsKilled++;
                                        int mask3 = ~(1 << curCol);
                                        topRow = topRow & mask;
                                    }
                                    mask2 = 1 << curCol;
                                    nAndMask2 = curRow & mask2;
                                    bit2 = nAndMask2 >> curCol;
                                    if (bit2 == 1)
                                    {
                                        pigsKilled++;
                                        int mask3 = ~(1 << curCol);
                                        curRow = curRow & mask;
                                    }
                                    mask2 = 1 << curCol;
                                    nAndMask2 = bottomRow & mask2;
                                    bit2 = nAndMask2 >> curCol;
                                    if (bit2 == 1)
                                    {
                                        pigsKilled++;
                                        int mask3 = ~(1 << curCol);
                                        bottomRow = bottomRow & mask;
                                    }
                                }
                                isPig = true;
                                switch (currentRow)
                                {
                                    case 0: row0 = curRow; row1 = bottomRow; break;
                                    case 1: row1 = curRow; row2 = bottomRow; row1 = topRow; break;
                                    case 2: row2 = curRow; row3 = bottomRow; row2 = topRow; break;
                                    case 3: row3 = curRow; row4 = bottomRow; row3 = topRow; break;
                                    case 4: row4 = curRow; row5 = bottomRow; row4 = topRow; break;
                                    case 5: row5 = curRow; row6 = bottomRow; row5 = topRow; break;
                                    case 6: row6 = curRow; row7 = bottomRow; row6 = topRow; break;
                                    case 7: row7 = curRow; row6 = topRow; break;
                                }
                            }
                        }
                        else
                        {
                            currentRow++;
                            isUp = true;
                            switch (currentRow)
                            {
                                case 0: curRow = row0; bottomRow = row1; break;
                                case 1: curRow = row1; bottomRow = row2; topRow = row0; break;
                                case 2: curRow = row2; bottomRow = row3; topRow = row1; break;
                                case 3: curRow = row3; bottomRow = row4; topRow = row2; break;
                                case 4: curRow = row4; bottomRow = row5; topRow = row3; break;
                                case 5: curRow = row5; bottomRow = row6; topRow = row4; break;
                                case 6: curRow = row6; bottomRow = row7; topRow = row5; break;
                                case 7: curRow = row7; topRow = row6; break;
                            }
                            posCounter++;
                            int mask1 = 1 << curCol;
                            int nAndMask1 = curRow & mask1;
                            int bit1 = nAndMask1 >> curCol;
                            if (bit1 == 1)
                            {
                                for (int z = curCol + 1; z >= curCol - 1; z--)
                                {
                                    int mask2 = 1 << z;
                                    int nAndMask2 = topRow & mask2;
                                    int bit2 = nAndMask2 >> z;
                                    if (bit2 == 1)
                                    {
                                        pigsKilled++;
                                        int mask3 = ~(1 << z);
                                        topRow = topRow & mask3;
                                    }
                                    mask2 = 1 << z;
                                    nAndMask2 = curRow & mask2;
                                    bit2 = nAndMask2 >> z;
                                    if (bit2 == 1)
                                    {
                                        pigsKilled++;
                                        int mask3 = ~(1 << z);
                                        curRow = curRow & mask3;
                                    }
                                    mask2 = 1 << z;
                                    nAndMask2 = bottomRow & mask2;
                                    bit2 = nAndMask2 >> z;
                                    if (bit2 == 1)
                                    {
                                        pigsKilled++;
                                        int mask3 = ~(1 << z);
                                        bottomRow = bottomRow & mask3;
                                    }
                                }
                                if (currentRow == 7)
                                {
                                    isEnd = true;
                                    break;
                                }
                                isPig = true;
                                switch (currentRow)
                                {
                                    case 0: row0 = curRow; row1 = bottomRow; break;
                                    case 1: row1 = curRow; row2 = bottomRow; row0 = topRow; break;
                                    case 2: row2 = curRow; row3 = bottomRow; row1 = topRow; break;
                                    case 3: row3 = curRow; row4 = bottomRow; row2 = topRow; break;
                                    case 4: row4 = curRow; row5 = bottomRow; row3 = topRow; break;
                                    case 5: row5 = curRow; row6 = bottomRow; row4 = topRow; break;
                                    case 6: row6 = curRow; row7 = bottomRow; row5 = topRow; break;
                                    case 7: row7 = curRow; row6 = topRow; break;
                                }
                            }
                        }
                    }
                    #endregion
                }              
            }           
            //Console.WriteLine(Convert.ToString(row0, 2).PadLeft(16, '0'));
            //Console.WriteLine(Convert.ToString(row1, 2).PadLeft(16, '0'));
            //Console.WriteLine(Convert.ToString(row2, 2).PadLeft(16, '0'));
            //Console.WriteLine(Convert.ToString(row3, 2).PadLeft(16, '0'));
            //Console.WriteLine(Convert.ToString(row4, 2).PadLeft(16, '0'));
            //Console.WriteLine(Convert.ToString(row5, 2).PadLeft(16, '0'));
            //Console.WriteLine(Convert.ToString(row6, 2).PadLeft(16, '0'));
            //Console.WriteLine(Convert.ToString(row7, 2).PadLeft(16, '0'));
        }
        Console.WriteLine(totalResult);
    }
}
