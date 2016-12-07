using System;

class SnakyTheSnake
{
    static void Main()
    {
        //coordinates
        string[] sizes = Console.ReadLine().Split('x');
        int rows = int.Parse(sizes[0].ToString());
        int cols = int.Parse(sizes[1].ToString());
        int entrence = 0;

        //create field
        string[,] matrix = new string[rows, cols];
        //fill the matrix(field)
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string currentLine = Console.ReadLine();
            //find the entrence
            if (row == 0)
            {
                for (int i = 0; i < currentLine[i]; i++)
                {
                    if (currentLine[i] == 's')
                    {
                        entrence = i;
                        break;
                    }
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentLine[col].ToString();
            }
        }


        //moves and direction
        string[] moves = Console.ReadLine().Split(',');

        //currentPosition
        int cRow = 0;
        int cCol = entrence;

        //lives
        int lives = 3;
        int counter = 0;

        //start the movement
        for (int i = 0; i < moves.Length; i++)
        {           
            switch (moves[i])
            {
                case "d": cRow++; break;
                case "u": cRow--; break;
                case "l": cCol--; break;
                case "r": cCol++; break;
            }

            if (cRow >= matrix.GetLength(0))
            {
                Console.WriteLine("Snacky will be lost into the depths with length {0}", lives);
                Environment.Exit(0);
            }

            if (cCol >= matrix.GetLength(1))
            {
                cCol = 0;
            }
            else if (cCol < 0)
            {
                cCol = matrix.GetLength(1) - 1;
            }

            //check for current element
            if (matrix[cRow, cCol] == "#")
            {
                Console.WriteLine("Snacky will hit a rock at [{0},{1}]", cRow, cCol);
                break;
            }
            else if (matrix[cRow, cCol] == "*")
            {
                lives++;
                matrix[cRow, cCol] = ".";
            }
            else if (matrix[cRow, cCol] == "s")
            {
                Console.WriteLine("Snacky will get out with length {0}", lives);
                break;
            }

            if (i == moves.Length - 1)
            {
                Console.WriteLine("Snacky will be stuck in the den at [{0},{1}]", cRow, cCol);
                break;
            }
            counter++;
            if (counter == 5)
            {
                lives--;
                if (lives <= 0)
                {
                    Console.WriteLine("Snacky will starve at [{0},{1}]", cRow, cCol);
                    Environment.Exit(0);
                }
                counter = 0;
            }
        }

    }

    static void printMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

