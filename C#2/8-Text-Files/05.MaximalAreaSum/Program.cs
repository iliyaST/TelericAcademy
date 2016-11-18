using System;
using System.IO;

class MaximalAreaSum
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\matrix.txt");
        StreamWriter writer = new StreamWriter(@"..\..\output.txt");
        int maxSum = int.MinValue;

        using (reader)
        {
            // read first line
            string currentLine = reader.ReadLine();
            //create matrix 
            int length = int.Parse(currentLine);
            int[,] matrix = new int[length, length];
            int row = 0;
            //read second line
            currentLine = reader.ReadLine();
            //filling the matrix
            //split the second line and transform it in to a readable row for the matrix
            string[] line = currentLine.Split(new char[] { ' ' });

            while (currentLine != null)
            {
                //fill the current row of the matrix
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
                //read next row from matrix
                currentLine = reader.ReadLine();
                //check if next row is null 
                if (currentLine != null)
                {
                    line = currentLine.Split(new char[] { ' ' });
                }
                //move to the next row of the matrix
                row++;
            }



            for (row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    int currentSum = matrix[row - 1, col - 1] + matrix[row - 1, col] + matrix[row, col - 1]
                        + matrix[row, col];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
        }

        using (writer)
        {
            writer.WriteLine(maxSum);
        }
    }
}

