using System;
using System.IO;

class FormulaBit1
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        Console.SetIn(sr);

        int row0 = int.Parse(Console.ReadLine());
        int row1 = int.Parse(Console.ReadLine());
        int row2 = int.Parse(Console.ReadLine());
        int row3 = int.Parse(Console.ReadLine());
        int row4 = int.Parse(Console.ReadLine());
        int row5 = int.Parse(Console.ReadLine());
        int row6 = int.Parse(Console.ReadLine());
        int row7 = int.Parse(Console.ReadLine());
        int counter = 1;
        string currentDirection = "south";
        int currentRow = row0;
        int currentCol = 0;
        int directionsCounter = 0;
        bool isEnd = false;
        bool isNorth = false;

        //South -> West -> North -> West 
        int mask = 1 << 0;
        int nAndMask = currentRow & mask;
        int bit = nAndMask >> 0;
        if (bit == 1)
        {
            counter++;
        }
        else
        {
            while (true)
            {
                if (isEnd == true)
                {
                    break;
                }
                #region south
                if (currentDirection == "south")
                {
                    if (currentRow == row0)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row1 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row0 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                counter++;
                                directionsCounter++;
                            }
                        }
                        else
                        {
                            currentRow = row1;
                            counter++;
                        }
                        continue;
                    }
                    if (currentRow == row1)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row2 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row1 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                counter++;
                                directionsCounter++;
                            }
                        }
                        else
                        {
                            currentRow = row2;
                            counter++;
                        }
                        continue;
                    }
                    if (currentRow == row2)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row3 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row2 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                counter++;
                                directionsCounter++;
                            }
                        }
                        else
                        {
                            currentRow = row3;
                            counter++;
                        }
                        continue;
                    }
                    if (currentRow == row3)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row4 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row3 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                counter++;
                                directionsCounter++;
                            }
                        }
                        else
                        {
                            currentRow = row4;
                            counter++;
                        }
                        continue;
                    }
                    if (currentRow == row4)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row5 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row4 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                counter++;
                                directionsCounter++;
                            }
                        }
                        else
                        {
                            currentRow = row5;
                            counter++;
                        }
                        continue;
                    }
                    if (currentRow == row5)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row6 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row5 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                counter++;
                                directionsCounter++;
                            }
                        }
                        else
                        {
                            currentRow = row6;
                            counter++;
                        }
                        continue;
                    }
                    if (currentRow == row6)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row7 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row6 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                counter++;
                                directionsCounter++;
                            }
                        }
                        else
                        {
                            currentRow = row7;
                            counter++;
                        }
                        continue;
                    }
                    if (currentRow == row7)
                    {
                        mask = 1 << currentCol + 1;
                        nAndMask = currentRow & mask;
                        bit = nAndMask >> currentCol + 1;
                        if (bit == 1 || (currentCol + 1) > 7)
                        {
                            isEnd = true;
                            break;
                        }
                        else
                        {
                            currentDirection = "west";
                            currentCol++;
                            counter++;
                            directionsCounter++;
                        }
                    }
                }
                #endregion
                #region west
                else if (currentDirection == "west")
                {
                    mask = 1 << currentCol + 1;
                    nAndMask = currentRow & mask;
                    bit = nAndMask >> currentCol + 1;
                    if (bit == 1 || (currentCol + 1) > 7)
                    {
                        if (currentRow == row0)
                        {
                            if (isNorth == true)
                            {
                                mask = 1 << currentCol;
                                nAndMask = row1 & mask;
                                bit = nAndMask >> currentCol;
                                if (bit == 0)
                                {
                                    currentRow = row1;
                                    counter++;
                                    currentDirection = "south";
                                    directionsCounter++;
                                }
                                else
                                {
                                    isEnd = true;
                                }
                            }
                            continue;
                        }
                        if (currentRow == row1)
                        {
                            mask = 1 << currentCol;
                            nAndMask = row0 & mask;
                            bit = nAndMask >> currentCol;
                            if (bit == 0)
                            {
                                if (bit == 0 && isNorth == false)
                                {
                                    currentRow = row0;
                                    counter++;
                                    currentDirection = "north";
                                    directionsCounter++;
                                }
                                else if (bit == 0 && isNorth == true)
                                {
                                    currentRow = row2;
                                    counter++;
                                    currentDirection = "south";
                                    directionsCounter++;
                                }
                            }
                            else
                            {
                                isEnd = true;
                                break;
                            }
                            continue;
                        }
                        if (currentRow == row2)
                        {
                            mask = 1 << currentCol;
                            nAndMask = row1 & mask;
                            bit = nAndMask >> currentCol;
                            if (bit == 0)
                            {
                                if (bit == 0 && isNorth == false)
                                {
                                    currentRow = row1;
                                    counter++;
                                    currentDirection = "north";
                                    directionsCounter++;
                                }
                                else if (bit == 0 && isNorth == true)
                                {
                                    currentRow = row3;
                                    counter++;
                                    currentDirection = "south";
                                    directionsCounter++;
                                }
                            }
                            else
                            {
                                isEnd = true;
                                break;
                            }
                            continue;
                        }
                        if (currentRow == row3)
                        {
                            mask = 1 << currentCol;
                            nAndMask = row2 & mask;
                            bit = nAndMask >> currentCol;
                            if (bit == 0)
                            {
                                if (bit == 0 && isNorth == false)
                                {
                                    currentRow = row2;
                                    counter++;
                                    currentDirection = "north";
                                    directionsCounter++;
                                }
                                else if (bit == 0 && isNorth == true)
                                {
                                    currentRow = row4;
                                    counter++;
                                    currentDirection = "south";
                                    directionsCounter++;
                                }
                            }
                            else
                            {
                                isEnd = true;
                                break;
                            }
                            continue;
                        }
                        if (currentRow == row4)
                        {
                            mask = 1 << currentCol;
                            nAndMask = row3 & mask;
                            bit = nAndMask >> currentCol;
                            if (bit == 0)
                            {
                                if (bit == 0 && isNorth == false)
                                {
                                    currentRow = row3;
                                    counter++;
                                    currentDirection = "north";
                                    directionsCounter++;
                                }
                                else if (bit == 0 && isNorth == true)
                                {
                                    currentRow = row5;
                                    counter++;
                                    currentDirection = "south";
                                    directionsCounter++;
                                }
                            }
                            else
                            {
                                isEnd = true;
                                break;
                            }
                            continue;
                        }
                        if (currentRow == row5)
                        {
                            mask = 1 << currentCol;
                            nAndMask = row4 & mask;
                            bit = nAndMask >> currentCol;
                            if (bit == 0)
                            {
                                if (bit == 0 && isNorth == false)
                                {
                                    currentRow = row4;
                                    counter++;
                                    currentDirection = "north";
                                    directionsCounter++;
                                }
                                else if (bit == 0 && isNorth == true)
                                {
                                    currentRow = row6;
                                    counter++;
                                    currentDirection = "south";
                                    directionsCounter++;
                                }
                            }
                            else
                            {
                                isEnd = true;
                                break;
                            }
                            continue;
                        }
                        if (currentRow == row6)
                        {
                            mask = 1 << currentCol;
                            nAndMask = row5 & mask;
                            bit = nAndMask >> currentCol;
                            if (bit == 0)
                            {
                                if (bit == 0 && isNorth == false)
                                {
                                    currentRow = row5;
                                    counter++;
                                    currentDirection = "north";
                                    directionsCounter++;
                                }
                                else if (bit == 0 && isNorth == true)
                                {
                                    currentRow = row7;
                                    counter++;
                                    currentDirection = "south";
                                    directionsCounter++;
                                }
                            }
                            else
                            {
                                isEnd = true;
                                break;
                            }
                            continue;
                        }
                        if (currentRow == row7)
                        {
                            mask = 1 << currentCol;
                            nAndMask = row6 & mask;
                            bit = nAndMask >> currentCol;
                            if (bit == 0)
                            {
                                if (bit == 0 && isNorth == false)
                                {
                                    currentRow = row6;
                                    counter++;
                                    currentDirection = "north";
                                    directionsCounter++;
                                }
                                else if (bit == 0 && isNorth == true)
                                {
                                    isEnd = true;
                                    break;
                                }
                            }
                            else
                            {
                                isEnd = true;
                                break;
                            }
                            continue;
                        }
                    }
                    else
                    {
                        currentCol++;
                        counter++;
                    }
                }
                #endregion
                #region north
                else if (currentDirection == "north")
                {
                    isNorth = true;
                    if (currentRow == row7)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row6 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row7 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                directionsCounter++;
                                counter++;
                            }
                        }
                        else
                        {
                            currentRow = row6;
                            counter++;
                        }
                    }
                    if (currentRow == row6)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row5 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row6 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                directionsCounter++;
                                counter++;
                            }
                        }
                        else
                        {
                            currentRow = row5;
                            counter++;
                        }
                    }
                    if (currentRow == row5)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row4 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row5 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                directionsCounter++;
                                counter++;
                            }
                        }
                        else
                        {
                            currentRow = row4;
                            counter++;
                        }
                    }
                    if (currentRow == row4)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row3 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row4 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                directionsCounter++;
                                counter++;
                            }
                        }
                        else
                        {
                            currentRow = row3;
                            counter++;
                        }
                    }
                    if (currentRow == row3)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row2 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row3 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                directionsCounter++;
                                counter++;
                            }
                        }
                        else
                        {
                            currentRow = row2;
                            counter++;
                        }
                    }
                    if (currentRow == row2)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row1 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row2 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                directionsCounter++;
                                counter++;
                            }
                        }
                        else
                        {
                            currentRow = row1;
                            counter++;
                        }
                    }
                    if (currentRow == row1)
                    {
                        mask = 1 << currentCol;
                        nAndMask = row0 & mask;
                        bit = nAndMask >> currentCol;
                        if (bit == 1)
                        {
                            mask = 1 << currentCol + 1;
                            nAndMask = row1 & mask;
                            bit = nAndMask >> currentCol + 1;
                            if (bit == 1)
                            {
                                isEnd = true;
                            }
                            else
                            {
                                currentDirection = "west";
                                currentCol++;
                                directionsCounter++;
                                counter++;
                            }
                        }
                        else
                        {
                            currentRow = row0;
                            counter++;
                        }
                    }
                    if (currentRow == row0)
                    {
                        mask = 1 << currentCol + 1;
                        nAndMask = row0 & mask;
                        bit = nAndMask >> currentCol + 1;
                        if (bit == 1)
                        {
                            isEnd = true;
                        }
                        else
                        {
                            currentDirection = "west";
                            currentCol++;
                            directionsCounter++;
                            counter++;
                        }
                    }
                }
                #endregion
            }
        }

        if (currentRow != row7)
        {
            Console.WriteLine("No {0}", counter);
        }
        else
        {
            Console.WriteLine("{0} {1}", counter, directionsCounter);
        }
    }
}

