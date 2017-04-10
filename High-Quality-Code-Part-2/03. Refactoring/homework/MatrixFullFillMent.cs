namespace FillTheMatrix
{
    public class MatrixFullFillment
    {
        public static void ChangeDirection(ref int directionPositionX, ref int directionPositionY)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == directionPositionX && dirY[count] == directionPositionY)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                directionPositionX = dirX[0];
                directionPositionY = dirY[0];
                return;
            }

            directionPositionX = dirX[cd + 1];
            directionPositionY = dirY[cd + 1];
        }

        public static bool CheckIfMatrixIsFull(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void FindZeroCell(int[,] matrix, out int foundRow, out int foundCol)
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
    }
}
