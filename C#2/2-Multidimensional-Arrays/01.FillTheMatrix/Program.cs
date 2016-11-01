using System;

class FillTheMatrix
{
    static void Main()
    {
        //Enter length
        int N = int.Parse(Console.ReadLine());
        //Enter witch task you want to complete
        string task = Console.ReadLine();
        //Declare N,N matrix
        int[,] matrix = new int[N, N];
        //Use counter to fill the matrix
        int counter = 1;

        //Task a
        #region a
        //......................................
        if (task == "a")
        {
            for (int col = 0; col < N; col++)
            {
                for (int row = 0; row < N; row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
        }
        //.....................................
        #endregion
        //Task b
        #region b
        //.....................................
        if (task == "b")
        {
            for (int col = 0; col < N; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < N; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = N - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }
        }
        //..............................................
        #endregion
        //Task c
        #region c
        //..............................................
        if (task == "c")
        {
            int startindex = N - 1;
            int col = 0;
            int rowlen = N - 1;
            int colstart = 1;
            bool cols = false;

            for (int i = 0; i < N + N + 1; i++)
            {
                for (int row = startindex; row <= rowlen; row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                    col++;
                }
                startindex--;
                col = 0;
                if (startindex == -1)
                {
                    cols = true;
                    startindex = 0;
                    col = colstart;
                    rowlen--;
                }
                if (cols == true)
                {
                    colstart++;
                }
            }
        }
        //..............................................
        #endregion
        //Task d
        #region d
        //.........................
        if (task == "d")
        {
            string direction = "down";
            int currentRow = 0;
            int currentCol = 0;

            for (int i = 1; i <= N * N; i++)
            {
                if (direction == "down" && (currentRow >= N ||
                    (matrix[currentRow, currentCol] != 0)))
                {
                    currentRow--;
                    currentCol++;
                    direction = "right";
                }
                else if (direction == "right" && (currentCol >= N ||
                    (matrix[currentRow, currentCol] != 0)))
                {
                    currentCol--;
                    currentRow--;
                    direction = "up";
                }
                else if (direction == "up" && (currentRow < 0 ||
                    (matrix[currentRow, currentCol] != 0)))
                {
                    currentRow++;
                    currentCol--;
                    direction = "left";
                }
                else if (direction == "left" && (currentCol < 0 ||
                    (matrix[currentRow, currentCol] != 0)))
                {
                    currentCol++;
                    currentRow++;
                    direction = "down";
                }

                matrix[currentRow, currentCol] = counter;
                counter++;

                if (direction == "down")
                {
                    currentRow++;
                }
                else if (direction == "right")
                {
                    currentCol++;
                }
                else if (direction == "up")
                {
                    currentRow--;
                }
                else if (direction == "left")
                {
                    currentCol--;
                }
            }
        }
        //.........................
        #endregion
        //print matrix
        #region print
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (col == N - 1)
                {
                    Console.Write(matrix[row, col]);
                    continue;
                }
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
        #endregion
    }
}
