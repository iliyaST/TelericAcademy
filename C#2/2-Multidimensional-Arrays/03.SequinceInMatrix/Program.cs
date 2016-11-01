using System;

class SequinceInMatrix
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);
        string[,] matrix = new string[N, M];
        //sequince veriables
        int maxSequince = 1;
        int currentSequince = 0;

        //fill the matrix
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            //enter current row
            string[] currentLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentLine[col];
            }
        }
        //check for longest sequince
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                //down
                if (row + 1 < N && matrix[row, col] == matrix[row + 1, col])
                {
                    for (int i = row; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[row, col] == matrix[i, col])
                        {
                            currentSequince++;
                        }
                        else
                        {
                            if (currentSequince > maxSequince)
                            {
                                maxSequince = currentSequince;
                            }
                            currentSequince = 0;
                            break;
                        }
                    }
                    if (currentSequince > maxSequince)
                    {
                        maxSequince = currentSequince;
                    }
                    currentSequince = 0;
                }
                //diagonal right
                if ((row + 1 < N && col + 1 < M) && matrix[row, col] == matrix[row + 1, col + 1])
                {
                    for (int i = row, j = col; i < N && j < M; i++, j++)
                    {
                        if (matrix[row, col] == matrix[i, j])
                        {
                            currentSequince++;
                        }
                        else
                        {
                            if (currentSequince > maxSequince)
                            {
                                maxSequince = currentSequince;
                            }
                            currentSequince = 0;
                            break;
                        }
                    }
                    if (currentSequince > maxSequince)
                    {
                        maxSequince = currentSequince;
                    }
                    currentSequince = 0;
                }
                //right
                if (col + 1 < M && matrix[row, col] == matrix[row, col + 1])
                {
                    for (int i = col; i < matrix.GetLength(1); i++)
                    {
                        if (matrix[row, col] == matrix[row, i])
                        {
                            currentSequince++;
                        }
                        else
                        {
                            if (currentSequince > maxSequince)
                            {
                                maxSequince = currentSequince;
                            }
                            currentSequince = 0;
                            break;
                        }
                    }
                    if (currentSequince > maxSequince)
                    {
                        maxSequince = currentSequince;
                    }
                    currentSequince = 0;
                }
                //left diagonal
                if ((col - 1 >= 0 && row + 1 < N) && matrix[row, col] == matrix[row + 1, col - 1])
                {
                    for (int i = row, j = col; i < N && j >= 0; i++, j--)
                    {
                        if (matrix[row, col] == matrix[i, j])
                        {
                            currentSequince++;
                        }
                        else
                        {
                            if (currentSequince > maxSequince)
                            {
                                maxSequince = currentSequince;
                            }
                            currentSequince = 0;
                            break;
                        }
                    }
                    if (currentSequince > maxSequince)
                    {
                        maxSequince = currentSequince;
                    }
                    currentSequince = 0;
                }
            }
        }
        Console.WriteLine(maxSequince);
    }
}

