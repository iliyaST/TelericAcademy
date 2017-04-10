namespace MatrixActions
{
    using System;

    public class MatrixActions
    {
        public static void ChangeDirection(ref int directionPositionX, ref int directionPositionY)
        {
            int[] currentDirectionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] currentDirectionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;

            for (int directionIndex = 0; directionIndex < 8; directionIndex++)
            {
                if (currentDirectionX[directionIndex] == directionPositionX &&
                    currentDirectionY[directionIndex] == directionPositionY)
                {
                    currentDirection = directionIndex;
                    break;
                }
            }

            if (currentDirection == 7)
            {
                directionPositionX = currentDirectionX[0];
                directionPositionY = currentDirectionY[0];
                return;
            }

            directionPositionX = currentDirectionX[currentDirection + 1];
            directionPositionY = currentDirectionY[currentDirection + 1];
        }

        public static bool CheckIfThereIsAPossibleCellToMove(int[,] matrix, int currentRow, int currentCol)
        {
            int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            // Check if there is a cell that is out of the matrix
            for (int i = 0; i < 8; i++)
            {
                if (currentRow + directionRow[i] >= matrix.GetLength(0) || currentRow + directionRow[i] < 0)
                {
                    directionRow[i] = 0;
                }

                if (currentCol + directionCol[i] >= matrix.GetLength(0) || currentCol + directionCol[i] < 0)
                {
                    directionCol[i] = 0;
                }
            }

            // Check if there is a cell that is empty
            for (int i = 0; i < 8; i++)
            {
                if (matrix[currentRow + directionRow[i], currentCol + directionCol[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindTheFirstPossibleEmptyCell(int[,] matrix, out int foundRow, out int foundCol)
        {
            var matrixLength = matrix.GetLength(0);
            foundRow = 0;
            foundCol = 0;

            for (int row = 0; row < matrixLength; row++)
            {
                for (int col = 0; col < matrixLength; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        foundRow = row;
                        foundCol = col;
                        return;
                    }
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            var matrixLength = matrix.GetLength(0);

            for (int row = 0; row < matrixLength; row++)
            {
                for (int col = 0; col < matrixLength; col++)
                {
                    Console.Write("{0,3}", matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("------------------------------------------------------------>");
        }
    }
}
