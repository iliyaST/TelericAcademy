//using System;

//class Warhead
//{
//    static void Main()
//    {
//        int[,] board = new int[16, 16];

//        for (int i = 0; i < 16; i++)
//        {
//            string currentLine = Console.ReadLine();
//            for (int j = 0; j < 16; j++)
//            {
//                char currentSymbol = currentLine[j];
//                board[i, j] = currentSymbol - '0';
//            }
//        }

//        while (true)
//        {
//            string currentOperator = Console.ReadLine();        
//            if(currentOperator=="cut")
//            {
//                string wire = Console.ReadLine();
//                if(wire=="blue")
//                {
//                    int currentRow = int.Parse(Console.ReadLine());
//                    int currentCow = int.Parse(Console.ReadLine());
//                    bool topLeft = false;
//                    bool topMiddle = false;
//                    bool topRight = false;
//                    bool middleLeft = false;
//                    bool middleRight = false;
//                    bool bottomLeft = false;
//                    bool bottomMiddle = false;
//                    bool bottomRight = false;
//                    int count = 0;
//                    for (int i = 1; i < 15; i++)
//                    {
//                        for (int j = 1; j < 15; j++)
//                        {
//                            int currentRow = i;
//                            int currentCow = j;
//                            int upperRow = currentRow - 1;
//                            int lowerRow = currentRow + 1;
//                            int leftCow = currentCow - 1;
//                            int rightCow = currentCow + 1;
//                            if ((leftCow - 1 >= 0 && upperRow - 1 >= 0) && board[upperRow, leftCow] == 1)
//                            {
//                                topLeft = true;
//                            }
//                            if ((upperRow >= 0 && currentCow >= 0) && board[upperRow, currentCow] == 1)
//                            {
//                                topMiddle = true;
//                            }
//                            if ((upperRow >= 0 && rightCow < 16) && board[upperRow, rightCow] == 1)
//                            {
//                                topRight = true;
//                            }
//                            if ((leftCow >= 0 && currentRow >= 0) && board[currentRow, leftCow] == 1)
//                            {
//                                middleLeft = true;
//                            }
//                            if ((lowerRow >= 0 && leftCow >= 0) && board[lowerRow, leftCow] == 1)
//                            {
//                                bottomLeft = true;
//                            }
//                            if ((lowerRow >= 0 && currentCow >= 0) && board[lowerRow, currentCow] == 1)
//                            {
//                                bottomMiddle = true;
//                            }
//                            if ((lowerRow >= 0 && rightCow < 16) && board[lowerRow, rightCow] == 1)
//                            {
//                                bottomRight = true;
//                            }
//                            if ((rightCow < 16 && currentRow >= 0) && board[currentRow, rightCow] == 1)
//                            {
//                                middleRight = true;
//                            }
//                            if (topLeft == true && topMiddle == true && topRight == true && middleLeft == true
//                                && middleRight == true && bottomLeft == true && bottomMiddle == true && bottomRight == true)
//                            {
//                                board[upperRow, leftCow] = 0;
//                                board[upperRow, currentCow] = 0;
//                                board[upperRow, rightCow] = 0;
//                                board[currentRow, leftCow] = 0;
//                                board[currentRow, rightCow] = 0;
//                                board[lowerRow, leftCow] = 0;
//                                board[lowerRow, currentCow] = 0;
//                                board[lowerRow, rightCow] = 0;
//                                count++;

//                            }
//                        }
//                    }
//                }
//                else
//                {

//                }
//            }   
//            if (currentOperator == "hover" || currentOperator == "operate")
//            {
//                if (currentOperator == "hover")
//                {
//                    int currentRow = int.Parse(Console.ReadLine());
//                    int currentCow = int.Parse(Console.ReadLine());
//                    if (board[currentRow, currentCow] == 1)
//                    {
//                        Console.WriteLine("*");
//                    }
//                    else
//                    {
//                        Console.WriteLine("-");
//                    }
//                }
//                if (currentOperator == "operate")
//                {
//                    int currentRow = int.Parse(Console.ReadLine());
//                    int currentCow = int.Parse(Console.ReadLine());
//                    bool topLeft = false;
//                    bool topMiddle = false;
//                    bool topRight = false;
//                    bool middleLeft = false;
//                    bool middleRight = false;
//                    bool bottomLeft = false;
//                    bool bottomMiddle = false;
//                    bool bottomRight = false;

//                    if (board[currentRow, currentCow] == 1)
//                    {
//                        int currentRow = int.Parse(Console.ReadLine());
//                        int currentCow = int.Parse(Console.ReadLine());
//                        bool topLeft = false;
//                        bool topMiddle = false;
//                        bool topRight = false;
//                        bool middleLeft = false;
//                        bool middleRight = false;
//                        bool bottomLeft = false;
//                        bool bottomMiddle = false;
//                        bool bottomRight = false;
//                        Console.WriteLine("missed");
//                        int count = 0;
//                        for (int i = 1; i < 15; i++)
//                        {
//                            for (int j = 1; j < 15; j++)
//                            {
//                                int upperRow = currentRow - 1;
//                                int lowerRow = currentRow + 1;
//                                int leftCow = currentCow - 1;
//                                int rightCow = currentCow + 1;
//                                if ((leftCow - 1 >= 0 && upperRow - 1 >= 0) && board[upperRow, leftCow] == 1)
//                                {
//                                    topLeft = true;
//                                }
//                                if ((upperRow >= 0 && currentCow >= 0) && board[upperRow, currentCow] == 1)
//                                {
//                                    topMiddle = true;
//                                }
//                                if ((upperRow >= 0 && rightCow < 16) && board[upperRow, rightCow] == 1)
//                                {
//                                    topRight = true;
//                                }
//                                if ((leftCow >= 0 && currentRow >= 0) && board[currentRow, leftCow] == 1)
//                                {
//                                    middleLeft = true;
//                                }
//                                if ((lowerRow >= 0 && leftCow >= 0) && board[lowerRow, leftCow] == 1)
//                                {
//                                    bottomLeft = true;
//                                }
//                                if ((lowerRow >= 0 && currentCow >= 0) && board[lowerRow, currentCow] == 1)
//                                {
//                                    bottomMiddle = true;
//                                }
//                                if ((lowerRow >= 0 && rightCow < 16) && board[lowerRow, rightCow] == 1)
//                                {
//                                    bottomRight = true;
//                                }
//                                if ((rightCow < 16 && currentRow >= 0) && board[currentRow, rightCow] == 1)
//                                {
//                                    middleRight = true;
//                                }
//                                if (topLeft == true && topMiddle == true && topRight == true && middleLeft == true
//                                    && middleRight == true && bottomLeft == true && bottomMiddle == true && bottomRight == true)
//                                {
//                                    board[upperRow, leftCow] = 0;
//                                    board[upperRow, currentCow] = 0;
//                                    board[upperRow, rightCow] = 0;
//                                    board[currentRow, leftCow] = 0;
//                                    board[currentRow, rightCow] = 0;
//                                    board[lowerRow, leftCow] = 0;
//                                    board[lowerRow, currentCow] = 0;
//                                    board[lowerRow, rightCow] = 0;
//                                    count++;

//                                }
//                            }
//                        }
//                        Console.WriteLine(count);
//                        Console.WriteLine("BOOM");
//                    }
//                    else
//                    {
//                        int upperRow = currentRow - 1;
//                        int lowerRow = currentRow + 1;
//                        int leftCow = currentCow - 1;
//                        int rightCow = currentCow + 1;
//                        if ((leftCow - 1 >= 0 && upperRow - 1 >= 0) && board[upperRow, leftCow] == 1)
//                        {
//                            topLeft = true;
//                        }
//                        if ((upperRow >= 0 && currentCow >= 0) && board[upperRow, currentCow] == 1)
//                        {
//                            topMiddle = true;
//                        }
//                        if ((upperRow >= 0 && rightCow < 16) && board[upperRow, rightCow] == 1)
//                        {
//                            topRight = true;
//                        }
//                        if ((leftCow >= 0 && currentRow >= 0) && board[currentRow, leftCow] == 1)
//                        {
//                            middleLeft = true;
//                        }
//                        if ((lowerRow >= 0 && leftCow >= 0) && board[lowerRow, leftCow] == 1)
//                        {
//                            bottomLeft = true;
//                        }
//                        if ((lowerRow >= 0 && currentCow >= 0) && board[lowerRow, currentCow] == 1)
//                        {
//                            bottomMiddle = true;
//                        }
//                        if ((lowerRow >= 0 && rightCow < 16) && board[lowerRow, rightCow] == 1)
//                        {
//                            bottomRight = true;
//                        }
//                        if ((rightCow < 16 && currentRow >= 0) && board[currentRow, rightCow] == 1)
//                        {
//                            middleRight = true;
//                        }
//                        if (topLeft == true && topMiddle == true && topRight == true && middleLeft == true
//                            && middleRight == true && bottomLeft == true && bottomMiddle == true && bottomRight == true)
//                        {
//                            board[upperRow, leftCow] = 0;
//                            board[upperRow, currentCow] = 0;
//                            board[upperRow, rightCow] = 0;
//                            board[currentRow, leftCow] = 0;
//                            board[currentRow, rightCow] = 0;
//                            board[lowerRow, leftCow] = 0;
//                            board[lowerRow, currentCow] = 0;
//                            board[lowerRow, rightCow] = 0;                          
//                        }
//                    }
//                }
//            }
//        }
//        //Console.WriteLine();
//        //for (int i = 0; i < 16; i++)
//        //{
//        //    for (int j = 0; j < 16; j++)
//        //    {
//        //        Console.Write(board[i, j]);
//        //    }
//        //    Console.WriteLine();
//        //}
//    }
//}