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

        int curRow = rows - 1;
        int curCol = 0;
        int index = 0;
        BigInteger sum = 0;
        sum += matrix[curRow, curCol];
        matrix[curRow, curCol] = 0;

        while (true)
        {
            //left or right
            while (curCol != newCoordinates[index])
            {
                if (curCol < newCoordinates[index])
                {
                    curCol++;
                    sum += matrix[curRow, curCol];
                    matrix[curRow, curCol] = 0;
                    continue;
                }
                else
                {
                    curCol--;
                    sum += matrix[curRow, curCol];
                    matrix[curRow, curCol] = 0;
                    continue;
                }
            }
            index++;
            //up or down
            while (curRow != newCoordinates[index])
            {
                if (curRow < newCoordinates[index])
                {
                    curRow++;
                    sum += matrix[curRow, curCol];
                    matrix[curRow, curCol] = 0;
                    continue;
                }
                else
                {
                    curRow--;
                    sum += matrix[curRow, curCol];
                    matrix[curRow, curCol] = 0;
                    continue;
                }
            }
            index++;
            if (index >= newCoordinates.Length)
            {
                break;
            }
        }

        Console.WriteLine(sum);
    }
}