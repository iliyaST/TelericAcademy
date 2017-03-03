namespace NamingIdentifiers
{
    using System;
    using System.Collections.Generic;

    public class Mines
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] board = CreatePlayingField();
            char[,] mines = PlacingMines();
            int minesFound = 0;
            bool stepOnMine = false;
            var champions = new List<ResultScore>(6);
            int currentRow = 0;
            int currentCol = 0;
            bool startGameFlag = true;
            const int TotalMinesOnField = 35;
            bool victoryFlag = false;

            do
            {
                if (startGameFlag)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintBoard(board);
                    startGameFlag = false;
                }

                Console.Write("Daj red i kolona : ");

                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out currentRow) &&
                    int.TryParse(command[2].ToString(), out currentCol) &&
                        currentRow <= board.GetLength(0) && currentCol <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        TopPlayersRanking(champions);
                        break;
                    case "restart":
                        board = CreatePlayingField();
                        mines = PlacingMines();
                        PrintBoard(board);
                        stepOnMine = false;
                        startGameFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[currentRow, currentCol] != '*')
                        {
                            if (mines[currentRow, currentCol] == '-')
                            {
                                StartTurn(board, mines, currentRow, currentCol);
                                minesFound++;
                            }

                            if (TotalMinesOnField == minesFound)
                            {
                                victoryFlag = true;
                            }
                            else
                            {
                                PrintBoard(board);
                            }
                        }
                        else
                        {
                            stepOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (stepOnMine)
                {
                    PrintBoard(mines);

                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", minesFound);

                    string niknejm = Console.ReadLine();
                    var t = new ResultScore(niknejm, minesFound);

                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].ScorePoints < t.ScorePoints)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((ResultScore r1, ResultScore r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((ResultScore r1, ResultScore r2) => r2.ScorePoints.CompareTo(r1.ScorePoints));

                    TopPlayersRanking(champions);
                    board = CreatePlayingField();
                    mines = PlacingMines();
                    minesFound = 0;
                    stepOnMine = false;
                    startGameFlag = true;
                }

                if (victoryFlag)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintBoard(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    var currentPlayerScore = new ResultScore(name, minesFound);
                    champions.Add(currentPlayerScore);
                    TopPlayersRanking(champions);
                    board = CreatePlayingField();
                    mines = PlacingMines();
                    minesFound = 0;
                    victoryFlag = false;
                    startGameFlag = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void TopPlayersRanking(List<ResultScore> totalPointsScored)
        {
            Console.WriteLine("\nTotal Score:");

            if (totalPointsScored.Count > 0)
            {
                for (int i = 0; i < totalPointsScored.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, totalPointsScored[i].Name, totalPointsScored[i].ScorePoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rating!\n");
            }
        }

        private static void StartTurn(char[,] board, char[,] mines, int currentRow, int currentCol)
        {
            char howManyMinesFound = CalculateMines(mines, currentRow, currentCol);
            mines[currentRow, currentCol] = howManyMinesFound;
            board[currentRow, currentCol] = howManyMinesFound;
        }

        private static void PrintBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;

            char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] PlacingMines()
        {
            int rows = 5;
            int cols = 10;

            char[,] board = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    board[row, col] = '-';
                }
            }

            var listOfRandomValues = new List<int>();

            while (listOfRandomValues.Count < 15)
            {
                var random = new Random();
                int randomGeneratedValue = random.Next(50);

                if (!listOfRandomValues.Contains(randomGeneratedValue))
                {
                    listOfRandomValues.Add(randomGeneratedValue);
                }
            }

            foreach (int randomValue in listOfRandomValues)
            {
                int currentCol = randomValue / cols;
                int currentRow = randomValue % cols;

                if (currentRow == 0 && randomValue != 0)
                {
                    currentCol--;
                    currentRow = rows;
                }
                else
                {
                    currentRow++;
                }

                board[currentCol, currentRow - 1] = '*';
            }

            return board;
        }

        private static void Calculations(char[,] board)
        {
            int currentCol = board.GetLength(0);
            int currentRow = board.GetLength(1);

            for (int i = 0; i < currentCol; i++)
            {
                for (int j = 0; j < currentRow; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char kolkoo = CalculateMines(board, i, j);
                        board[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char CalculateMines(char[,] board, int currentRow, int currentCol)
        {
            int sum = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (board[currentRow - 1, currentCol] == '*')
                {
                    sum++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (board[currentRow + 1, currentCol] == '*')
                {
                    sum++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (board[currentRow, currentCol - 1] == '*')
                {
                    sum++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (board[currentRow, currentCol + 1] == '*')
                {
                    sum++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (board[currentRow - 1, currentCol - 1] == '*')
                {
                    sum++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (board[currentRow - 1, currentCol + 1] == '*')
                {
                    sum++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (board[currentRow + 1, currentCol - 1] == '*')
                {
                    sum++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (board[currentRow + 1, currentCol + 1] == '*')
                {
                    sum++;
                }
            }

            return char.Parse(sum.ToString());
        }
    }
}
