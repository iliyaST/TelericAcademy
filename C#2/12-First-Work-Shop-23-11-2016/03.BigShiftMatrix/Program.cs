using System;
using System.Numerics;

class BigShiftMatrix
{
    static long[] getCoordinates(string[] coordinates, int rows, int cols)
    {
        long[] array = new long[coordinates.Length * 2];
        int index = 0;
        long max = Math.Max(rows, cols);

        foreach (var coordinate in coordinates)
        {
            long temp = long.Parse(coordinate);
            array[index] = temp % max;
            array[index + 1] = temp / max;
            index += 2;
        }

        return array;
    }

    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        int numberOfMoves = int.Parse(Console.ReadLine());
        BigInteger[,] matrix = new BigInteger[rows, cols];
        string[] coordinates = Console.ReadLine().Split(' ');
        //create new array witch will keep  our coordinates 
        long[] newCoordinates = getCoordinates(coordinates, rows, cols);

        //fill the matrix
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = (BigInteger)Math.Pow(2, rows - row - 1 + col);
            }
        }

        int currentRow = rows - 1;
        int currentCol = 0;
        string direction = "";
        int index = 0;
        BigInteger sum = 0;
        #region check current direction
        if (newCoordinates[0] > currentCol)
        {
            direction = "right";
            sum += matrix[currentRow, currentCol];
            matrix[currentRow, currentCol] = 0;
        }
        else if (newCoordinates[0] == currentCol && newCoordinates[1] < currentRow)
        {
            direction = "up";
            sum += matrix[currentRow, currentCol];
            matrix[currentRow, currentCol] = 0;
        }
        else if ((newCoordinates[0] == currentCol && newCoordinates[1] == currentRow))
        {
            sum += matrix[currentRow, currentCol];
            matrix[currentRow, currentCol] = 0;
            index += 2;
            if (newCoordinates[index] > currentCol)
            {
                direction = "right";
            }
            else if (newCoordinates[index] == currentCol && newCoordinates[index + 1] < currentRow)
            {
                direction = "up";
            }
        }
        #endregion
        while (true)
        {
            #region left or right
            //left or right
            if (direction != "down" && direction != "up")
            {
                while (true)
                {
                    if (direction == "right")
                    {
                        currentCol++;
                        sum += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;
                    }
                    else if (direction == "left")
                    {
                        currentCol--;
                        sum += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;
                    }
                    if (currentCol == newCoordinates[index])
                    {
                        break;
                    }
                }
                index++;
            }
            #endregion
            #region check down or up or if row is equal move next el
            if (newCoordinates[index] > currentRow)
            {
                direction = "down";
            }
            else if (newCoordinates[index] < currentRow)
            {
                direction = "up";
            }
            else if (newCoordinates[index] == currentRow)
            {
                index++;
                if (index >= newCoordinates.Length - 1)
                {
                    Console.WriteLine(sum);
                    Environment.Exit(0);
                }

                if (newCoordinates[index] > currentCol)
                {
                    direction = "right";
                }
                else
                {
                    direction = "left";
                }
            }
            #endregion
            #region up or down
            //up or down
            if (direction != "right" && direction != "left")
            {
                while (true)
                {
                    if (direction == "up")
                    {
                        currentRow--;
                        sum += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;

                    }
                    else if (direction == "down")
                    {
                        currentRow++;
                        sum += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;

                    }
                    if (currentRow == newCoordinates[index])
                    {
                        break;
                    }
                }
                index++;
            }
            #endregion
            #region check if right or left or if its on the same col up or down
            if (index >= newCoordinates.Length)
            {
                Console.WriteLine(sum);
                Environment.Exit(0);
            }

            if (newCoordinates[index] > currentCol)
            {
                direction = "right";
            }
            else if (newCoordinates[index] < currentCol)
            {
                direction = "left";
            }
            else if (newCoordinates[index] == currentCol)
            {
                index++;
                if (newCoordinates[index] > currentRow)
                {
                    direction = "down";
                }
                else if (newCoordinates[index] < currentRow)
                {
                    direction = "up";
                }
                else if (newCoordinates[index] == currentRow)
                {
                    index++;
                    if (index >= newCoordinates.Length - 1)
                    {
                        Console.WriteLine(sum);
                        Environment.Exit(0);
                    }
                    if (newCoordinates[index] > currentCol)
                    {
                        direction = "right";
                    }
                    else if (newCoordinates[index] < currentCol)
                    {
                        direction = "left";
                    }
                }
            }
            #endregion
        }

    }
}

