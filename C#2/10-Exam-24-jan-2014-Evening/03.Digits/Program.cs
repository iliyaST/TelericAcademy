using System;

class Digits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int totalResult = 0;

        for (int row = 0; row < n; row++)
        {
            //enter current row
            string[] currentLine = Console.ReadLine().Split(new char[] { ' ' });
            for (int col = 0; col < currentLine.Length; col++)
            {
                matrix[row, col] = int.Parse(currentLine[col]);
            }
        }

        for (int row = 0; row < n - 2; row++)
        {
            for (int col = 0; col < n - 2; col++)
            {
                switch (matrix[row, col])
                {
                    //case 0: break;
                    case 1:
                        {
                            if (row != 0 && row != 1)

                            {
                                if (matrix[row - 1, col + 1] == 1 && matrix[row - 2, col + 2] == 1
                                    && matrix[row - 1, col + 2] == 1 && matrix[row, col + 2] == 1
                                    && matrix[row + 1, col + 2] == 1 && matrix[row + 2, col + 2] == 1)
                                {
                                    totalResult += 1;
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            if (row != 0 && row != n - 3)

                            {
                                if (matrix[row - 1, col + 1] == 2 && matrix[row, col + 2] == 2 &&
                                    matrix[row + 1, col + 2] == 2 && matrix[row + 2, col + 1] == 2 &&
                                    matrix[row + 3, col] == 2 && matrix[row + 3, col + 1] == 2 &&
                                    matrix[row + 3, col + 2] == 2)
                                {
                                    totalResult += 2;
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            if (row != n - 4 && row != n - 3)

                            {
                                if (matrix[row, col + 1] == 3 && matrix[row, col + 2] == 3 &&
                                    matrix[row + 1, col + 2] == 3 && matrix[row + 2, col + 2] == 3 &&
                                    matrix[row + 2, col + 1] == 3 && matrix[row + 3, col + 2] == 3 &&
                                    matrix[row + 4, col] == 3
                                    && matrix[row + 4, col + 1] == 3 && matrix[row + 4, col + 2] == 3)
                                {
                                    totalResult += 3;
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            if (row != n - 4 && row != n - 3)
                               
                            {
                                if (matrix[row + 1, col] == 4 && matrix[row + 2, col] == 4 &&
                                    matrix[row + 2, col + 1] == 4 && matrix[row + 2, col + 2] == 4 &&
                                    matrix[row, col + 2] == 4 && matrix[row + 1, col + 2] == 4 &&
                                    matrix[row + 3, col + 2] == 4 && matrix[row + 4, col + 2] == 4)
                                {
                                    totalResult += 4;
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            if (row != n - 4 && row != n - 3)
                              
                            {
                                if (matrix[row + 1, col] == 5 && matrix[row + 2, col] == 5 &&
                                    matrix[row + 2, col + 1] == 5 && matrix[row + 2, col + 2] == 5 &&
                                    matrix[row, col + 1] == 5 && matrix[row, col + 2] == 5 &&
                                    matrix[row + 3, col + 2] == 5 && matrix[row + 4, col] == 5 &&
                                    matrix[row + 4, col + 1] == 5 && matrix[row + 4, col + 2] == 5)
                                {
                                    totalResult += 5;
                                }
                            }
                            break;
                        }
                    case 6:
                        {
                            if (row != n - 4 && row != n - 3)
                               
                            {
                                if (matrix[row + 1, col] == 6 && matrix[row + 2, col] == 6 &&
                                    matrix[row + 2, col + 1] == 6 && matrix[row + 2, col + 2] == 6 &&
                                    matrix[row, col + 1] == 6 && matrix[row, col + 2] == 6 &&
                                    matrix[row + 3, col + 2] == 6 && matrix[row + 4, col] == 6 &&
                                    matrix[row + 4, col + 1] == 6 && matrix[row + 4, col + 2] == 6 &&
                                    matrix[row + 3, col] == 6)
                                {
                                    totalResult += 6;
                                }
                            }
                            break;
                        }
                    case 7:
                        {
                            if (row != n - 4 && row != n - 3)
                              
                            {
                                if (matrix[row, col + 1] == 7 && matrix[row, col + 2] == 7 &&
                                    matrix[row + 1, col + 2] == 7 && matrix[row + 2, col + 1] == 7 &&
                                    matrix[row + 3, col + 1] == 7 && matrix[row + 4, col + 1] == 7)
                                {
                                    totalResult += 7;
                                }
                            }
                            break;
                        }
                    case 8:
                        {
                            if (row != n - 4 && row != n - 3 && row != n && row != n - 2 && row != n - 1 &&
                               col != n - 1 && col != n - 2)
                            {
                                if (matrix[row, col + 1] == 8 && matrix[row, col + 2] == 8 &&
                                    matrix[row + 1, col] == 8 && matrix[row + 1, col + 2] == 8 &&
                                    matrix[row + 2, col + 1] == 8 && matrix[row + 3, col] == 8 &&
                                    matrix[row + 3, col + 2] == 8 && matrix[row + 4, col] == 8 &&
                                    matrix[row + 4, col + 1] == 8 && matrix[row + 4, col + 2] == 8)
                                {
                                    totalResult += 8;
                                }
                            }
                            break;
                        }
                    case 9:
                        {
                            if (row != n - 4 && row != n - 3 && row != n && row != n - 2 && row != n - 1 &&
                               col != n - 1 && col != n - 2)
                            {
                                if (matrix[row, col + 1] == 9 && matrix[row, col + 2] == 9 &&
                                    matrix[row + 1, col] == 9 && matrix[row + 1, col + 2] == 9 &&
                                    matrix[row + 2, col + 1] == 9 && matrix[row + 2, col + 2] == 9
                                    && matrix[row + 3, col + 2] == 9 && matrix[row + 4, col] == 9 &&
                                    matrix[row + 4, col + 1] == 9 && matrix[row + 4, col + 2] == 9)
                                {
                                    totalResult += 9;
                                }
                            }
                            break;
                        }
                }
            }
        }
        Console.WriteLine(totalResult);
    }
}

