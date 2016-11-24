using System;
using System.IO;

class Patterns
{
    static void Main()
    {
        //StreamReader sr = new StreamReader("../../input.txt");
        //Console.SetIn(sr);

        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        bool isFound = false;
        int max = int.MinValue;
        int sumDiagonal = 0;

        for (int row = 0; row < n; row++)
        {
            string[] currentLine = Console.ReadLine().Split(' ');

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = int.Parse(currentLine[col]);
            }
        }

        for (int row = 0; row <= n - 3; row++)
        {
            for (int col = 0; col <= n - 5; col++)
            {
                if (matrix[row, col + 1] == matrix[row, col] + 1
                    && matrix[row, col + 2] == matrix[row, col + 1] + 1
                    && matrix[row + 1, col + 2] == matrix[row, col + 2] + 1
                    && matrix[row + 2, col + 2] == matrix[row + 1, col + 2] + 1
                    && matrix[row + 2, col + 3] == matrix[row + 2, col + 2] + 1
                    && matrix[row + 2, col + 4] == matrix[row + 2, col + 3] + 1)
                {
                    int currentSum = matrix[row, col + 1] + matrix[row, col] + matrix[row, col + 2] +
                        matrix[row + 1, col + 2] + matrix[row + 2, col + 2] + matrix[row + 2, col + 3] +
                        matrix[row + 2, col + 4];
                    if (max < currentSum)
                    {
                        max = currentSum;
                    }
                    isFound = true;
                }
            }
        }

        if (isFound)
        {
            Console.WriteLine("YES {0}", max);
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                sumDiagonal += matrix[i, i];
            }
            Console.WriteLine("NO {0}", sumDiagonal);
        }
    }
}

