using System;
using System.IO;

class GameOfPage
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        Console.SetIn(sr);

        string row0 = Console.ReadLine();
        string row1 = Console.ReadLine();
        string row2 = Console.ReadLine();
        string row3 = Console.ReadLine();
        string row4 = Console.ReadLine();
        string row5 = Console.ReadLine();
        string row6 = Console.ReadLine();
        string row7 = Console.ReadLine();
        string row8 = Console.ReadLine();
        string row9 = Console.ReadLine();
        string row10 = Console.ReadLine();
        string row11 = Console.ReadLine();
        string row12 = Console.ReadLine();
        string row13 = Console.ReadLine();
        string row14 = Console.ReadLine();
        string row15 = Console.ReadLine();
        int middleCounter = 0;
        int upperCounter = 0;
        int lowerCounter = 0;
        int cookieCounter = 0;
        while (true)
        {
            string currentCommand = Console.ReadLine();
            #region paypal
            if (currentCommand == "paypal")
            {
                Console.WriteLine("${0:F2}", cookieCounter * 1.79);
                break;
            }
            #endregion
            #region what is
            if (currentCommand == "what is")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                long tempUpperRow = 0;
                long tempMiddleRow = 0;
                long tempLowerRow = 0;

                switch (row)
                {
                    case 0: tempMiddleRow = Convert.ToInt64(row0, 2); tempLowerRow = Convert.ToInt64(row1, 2); break;
                    case 1: tempUpperRow = Convert.ToInt64(row0, 2); tempMiddleRow = Convert.ToInt64(row1, 2); tempLowerRow = Convert.ToInt64(row2, 2); break;
                    case 2: tempUpperRow = Convert.ToInt64(row1, 2); tempMiddleRow = Convert.ToInt64(row2, 2); tempLowerRow = Convert.ToInt64(row3, 2); break;
                    case 3: tempUpperRow = Convert.ToInt64(row2, 2); tempMiddleRow = Convert.ToInt64(row3, 2); tempLowerRow = Convert.ToInt64(row4, 2); break;
                    case 4: tempUpperRow = Convert.ToInt64(row3, 2); tempMiddleRow = Convert.ToInt64(row4, 2); tempLowerRow = Convert.ToInt64(row5, 2); break;
                    case 5: tempUpperRow = Convert.ToInt64(row4, 2); tempMiddleRow = Convert.ToInt64(row5, 2); tempLowerRow = Convert.ToInt64(row6, 2); break;
                    case 6: tempUpperRow = Convert.ToInt64(row5, 2); tempMiddleRow = Convert.ToInt64(row6, 2); tempLowerRow = Convert.ToInt64(row7, 2); break;
                    case 7: tempUpperRow = Convert.ToInt64(row6, 2); tempMiddleRow = Convert.ToInt64(row7, 2); tempLowerRow = Convert.ToInt64(row8, 2); break;
                    case 8: tempUpperRow = Convert.ToInt64(row7, 2); tempMiddleRow = Convert.ToInt64(row8, 2); tempLowerRow = Convert.ToInt64(row9, 2); break;
                    case 9: tempUpperRow = Convert.ToInt64(row8, 2); tempMiddleRow = Convert.ToInt64(row9, 2); tempLowerRow = Convert.ToInt64(row10, 2); break;
                    case 10: tempUpperRow = Convert.ToInt64(row9, 2); tempMiddleRow = Convert.ToInt64(row10, 2); tempLowerRow = Convert.ToInt64(row11, 2); break;
                    case 11: tempUpperRow = Convert.ToInt64(row10, 2); tempMiddleRow = Convert.ToInt64(row11, 2); tempLowerRow = Convert.ToInt64(row12, 2); break;
                    case 12: tempUpperRow = Convert.ToInt64(row11, 2); tempMiddleRow = Convert.ToInt64(row12, 2); tempLowerRow = Convert.ToInt64(row13, 2); break;
                    case 13: tempUpperRow = Convert.ToInt64(row12, 2); tempMiddleRow = Convert.ToInt64(row13, 2); tempLowerRow = Convert.ToInt64(row14, 2); break;
                    case 14: tempUpperRow = Convert.ToInt64(row13, 2); tempMiddleRow = Convert.ToInt64(row14, 2); tempLowerRow = Convert.ToInt64(row15, 2); break;
                    case 15: tempMiddleRow = Convert.ToInt64(row15, 2); tempUpperRow = Convert.ToInt64(row14, 2); break;
                }
                //Console.WriteLine(Convert.ToString(tempLowerRow, 2).PadLeft(16,'0'));
                //Console.WriteLine(Convert.ToString(tempMiddleRow, 2).PadLeft(16, '0'));
                //Console.WriteLine(Convert.ToString(tempUpperRow, 2).PadLeft(16,'0'));
                int mask = 1 << 15 - col;
                long nAndMask = tempMiddleRow & mask;
                long bit = nAndMask >> 15 - col;
                if (bit == 0)
                {
                    Console.WriteLine("smile");
                    continue;
                }
                if (bit == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        mask = 1 << 15 - col - 1 + i;
                        nAndMask = tempMiddleRow & mask;
                        bit = nAndMask >> 15 - col - 1 + i;
                        if (bit == 1)
                        {
                            middleCounter++;
                        }
                        mask = 1 << 15 - col - 1 + i;
                        long nAndMaskUpper = tempUpperRow & mask;
                        bit = nAndMaskUpper >> 15 - col - 1 + i;
                        if (bit == 1)
                        {
                            upperCounter++;
                        }
                        mask = 1 << 15 - col - 1 + i;
                        long nAndMaskLower = tempLowerRow & mask;
                        bit = nAndMaskLower >> 15 - col - 1 + i;
                        if (bit == 1)
                        {
                            lowerCounter++;
                        }
                    }
                    if (upperCounter == lowerCounter && lowerCounter == upperCounter
                        && upperCounter == 3)
                    {
                        Console.WriteLine("cookie");
                    }
                    else
                    {
                        //Console.WriteLine(Convert.ToString(tempMiddleRow, 2).PadLeft(16, '0'));
                        mask = 1 << 15 - col;
                        nAndMask = tempMiddleRow & mask;
                        // Console.WriteLine(Convert.ToString(nAndMask, 2).PadLeft(16, '0'));
                        bit = nAndMask >> 15 - col;
                        if (bit == 1 && upperCounter == 0 && lowerCounter == 0 && middleCounter == 1)
                        {
                            Console.WriteLine("cookie crumb");
                        }
                        else
                        {
                            Console.WriteLine("broken cookie");
                        }
                    }
                    middleCounter = 0;
                    upperCounter = 0;
                    lowerCounter = 0;
                }
            }
            #endregion
            #region buy
            if (currentCommand == "buy")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                long tempUpperRow = 0;
                long tempMiddleRow = 0;
                long tempLowerRow = 0;

                switch (row)
                {
                    case 0: tempMiddleRow = Convert.ToInt64(row0, 2); break;
                    case 1: tempUpperRow = Convert.ToInt64(row0, 2); tempMiddleRow = Convert.ToInt64(row1, 2); tempLowerRow = Convert.ToInt64(row2, 2); break;
                    case 2: tempUpperRow = Convert.ToInt64(row1, 2); tempMiddleRow = Convert.ToInt64(row2, 2); tempLowerRow = Convert.ToInt64(row3, 2); break;
                    case 3: tempUpperRow = Convert.ToInt64(row2, 2); tempMiddleRow = Convert.ToInt64(row3, 2); tempLowerRow = Convert.ToInt64(row4, 2); break;
                    case 4: tempUpperRow = Convert.ToInt64(row3, 2); tempMiddleRow = Convert.ToInt64(row4, 2); tempLowerRow = Convert.ToInt64(row5, 2); break;
                    case 5: tempUpperRow = Convert.ToInt64(row4, 2); tempMiddleRow = Convert.ToInt64(row5, 2); tempLowerRow = Convert.ToInt64(row6, 2); break;
                    case 6: tempUpperRow = Convert.ToInt64(row5, 2); tempMiddleRow = Convert.ToInt64(row6, 2); tempLowerRow = Convert.ToInt64(row7, 2); break;
                    case 7: tempUpperRow = Convert.ToInt64(row6, 2); tempMiddleRow = Convert.ToInt64(row7, 2); tempLowerRow = Convert.ToInt64(row8, 2); break;
                    case 8: tempUpperRow = Convert.ToInt64(row7, 2); tempMiddleRow = Convert.ToInt64(row8, 2); tempLowerRow = Convert.ToInt64(row9, 2); break;
                    case 9: tempUpperRow = Convert.ToInt64(row8, 2); tempMiddleRow = Convert.ToInt64(row9, 2); tempLowerRow = Convert.ToInt64(row10, 2); break;
                    case 10: tempUpperRow = Convert.ToInt64(row9, 2); tempMiddleRow = Convert.ToInt64(row10, 2); tempLowerRow = Convert.ToInt64(row11, 2); break;
                    case 11: tempUpperRow = Convert.ToInt64(row10, 2); tempMiddleRow = Convert.ToInt64(row11, 2); tempLowerRow = Convert.ToInt64(row12, 2); break;
                    case 12: tempUpperRow = Convert.ToInt64(row11, 2); tempMiddleRow = Convert.ToInt64(row12, 2); tempLowerRow = Convert.ToInt64(row13, 2); break;
                    case 13: tempUpperRow = Convert.ToInt64(row12, 2); tempMiddleRow = Convert.ToInt64(row13, 2); tempLowerRow = Convert.ToInt64(row14, 2); break;
                    case 14: tempUpperRow = Convert.ToInt64(row13, 2); tempMiddleRow = Convert.ToInt64(row14, 2); tempLowerRow = Convert.ToInt64(row15, 2); break;
                    case 15: tempMiddleRow = Convert.ToInt64(row15, 2); break;
                }
                int mask = 1 << 15 - col;
                long nAndMask = tempMiddleRow & mask;
                long bit = nAndMask >> 15 - col;
                if (bit == 0)
                {
                    Console.WriteLine("smile");
                }
                else if (bit == 1)
                {
                    if (row == 0 || row == 15)
                    {
                        Console.WriteLine("page");
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            mask = 1 << 15 - col - 1 + i;

                            nAndMask = tempMiddleRow & mask;

                            bit = nAndMask >> 15 - col - 1 + i;
                            if (bit == 1)
                            {
                                middleCounter++;
                            }
                            mask = 1 << 15 - col - 1 + i;

                            long nAndMaskUpper = tempUpperRow & mask;
                            bit = nAndMaskUpper >> 15 - col - 1 + i;
                            if (bit == 1)
                            {
                                upperCounter++;
                            }
                            mask = 1 << 15 - col - 1 + i;
                            long nAndMaskLower = tempLowerRow & mask;
                            bit = nAndMaskLower >> 15 - col - 1 + i;
                            if (bit == 1)
                            {
                                lowerCounter++;
                            }
                        }
                        if (upperCounter == lowerCounter && lowerCounter == upperCounter
                            && upperCounter == 3)
                        {                            
                            cookieCounter++;
                        }
                        else
                        {
                            //Console.WriteLine(Convert.ToString(tempMiddleRow, 2).PadLeft(16, '0'));
                            mask = 1 << 15 - col;
                            nAndMask = tempMiddleRow & mask;
                            // Console.WriteLine(Convert.ToString(nAndMask, 2).PadLeft(16, '0'));
                            bit = nAndMask >> 15 - col;
                            if (bit == 1 && upperCounter == 0 && lowerCounter == 0 && middleCounter == 1)
                            {
                                Console.WriteLine("page");
                            }
                            else
                            {
                                Console.WriteLine("page");
                            }
                        }
                        middleCounter = 0;
                        upperCounter = 0;
                        lowerCounter = 0;
                    }
                }
            }
            #endregion
        }
    }
}

