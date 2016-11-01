using System;

class LargestAreaOfMatrix
{
    static void Main()
    {
        string[] consoleInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int N = int.Parse(consoleInput[0]);
        int M = int.Parse(consoleInput[1]);
        int[,] matrix = new int[N, M];
        bool neibhor = false;

        //longest sequince
        int currentSequence = 0;
        int maxSequince = 0;

        // fill the matrix
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = int.Parse(line[col]);
            }
        }

        //check for longest sequince
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
               
            }
        }
    }
}

