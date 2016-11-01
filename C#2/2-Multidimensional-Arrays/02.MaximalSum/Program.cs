using System;

class MaximalSUm
{
    static void Main()
    {
        //Enter N and M on single Line using space
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //With split function we save the value in N and M 
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);
        // Inizialise matrix's dimensons lenght.
        int[,] matrix = new int[N, M];

        //fill the matrix
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            //enter row with spaces
            string[] input1 = Console.ReadLine().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < matrix.GetLength(1); col++)
            {

                matrix[row, col] = int.Parse(input1[col]);
            }
        }

        //sum
        long maxSum = int.MinValue;
        long currentSum = 0;

        //Algorithm for sum
        for (int row = 1; row < N - 1; row++)
        {
            for (int col = 1; col < M - 1; col++)
            {
                currentSum = matrix[row, col] + 
                    matrix[row - 1, col] + matrix[row - 1, col + 1] +
                    matrix[row, col - 1] + matrix[row, col + 1] +
                    matrix[row + 1, col - 1] + matrix[row + 1, col] +
                    matrix[row + 1, col + 1] + matrix[row - 1, col - 1];

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        //Printing max SUm
        Console.WriteLine(maxSum);
    }
}

