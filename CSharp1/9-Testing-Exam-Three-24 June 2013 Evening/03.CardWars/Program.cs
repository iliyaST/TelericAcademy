using System;

class CardWars
{
    static void Main()
    {
        int numberOfRounds = int.Parse(Console.ReadLine());
        int counter = 0;
        int firstCardPlayerA = 0;
        int secondCardPlayerA = 0;
        int thirdCardPlayerA = 0;
        int firstCardPlayerB = 0;
        int secondCardPlayerB = 0;
        int thirdCardPlayerB = 0;
        int resultA = 0;
        int resultB = 0;
        int gamesWonA = 0;
        int gamesWonB = 0;
        bool isZ = false;
        bool isY = false;
        bool isX = false;

        for (int i = 0; i < 6 * numberOfRounds; i++)
        {
            string temp = Console.ReadLine();
            switch (temp)
            {
                case "2":
                    temp = "10";
                    break;
                case "3":
                    temp = "9";
                    break;
                case "4":
                    temp = "8";
                    break;
                case "5":
                    temp = "7";
                    break;
                case "6":
                    temp = "6";
                    break;
                case "7":
                    temp = "5";
                    break;
                case "8":
                    temp = "4";
                    break;
                case "9":
                    temp = "3";
                    break;
                case "10":
                    temp = "2";
                    break;
                case "A":
                    temp = "1";
                    break;
                case "J":
                    temp = "11";
                    break;
                case "Q":
                    temp = "12";
                    break;
                case "K":
                    temp = "13";
                    break;
                case "Z":
                    if (counter > 3)
                    {
                        resultB *= 2;
                    }
                    if (counter <= 3)
                    {
                        resultA *= 2;
                    }
                    isZ = true;
                    break;
                case "Y":
                    if (counter <= 3)
                    {
                        resultA -= 200;
                    }
                    if (counter > 3)
                    {
                        resultB -= 200;
                    }
                    isY = true;
                    break;
                case "X":
                    {
                        temp = "14";
                        isX = true;
                        break;
                    }
            }
            if (isZ == true || isY == true)
            {
                isZ = false;
                isY = false;
                counter++;
                continue;
            }
            counter++;
            if (counter == 1)
            {
                firstCardPlayerA = int.Parse(temp);
                continue;
            }
            if (counter == 2)
            {
                secondCardPlayerA = int.Parse(temp);
                continue;
            }
            if (counter == 3)
            {
                thirdCardPlayerA = int.Parse(temp);
                continue;
            }
            if (counter == 4)
            {
                firstCardPlayerB = int.Parse(temp);
                continue;
            }
            if (counter == 5)
            {
                secondCardPlayerB = int.Parse(temp);
                continue;
            }
            if (counter == 6)
            {
                thirdCardPlayerB = int.Parse(temp);
                counter = 0;
                int playerAscore = firstCardPlayerA + secondCardPlayerA + thirdCardPlayerA;
                int playerBscore = firstCardPlayerB + secondCardPlayerB + thirdCardPlayerB;
                if ((firstCardPlayerA == 14 || secondCardPlayerA == 14 || thirdCardPlayerA == 14) && (firstCardPlayerB != 14 &&
                    secondCardPlayerB != 14 && thirdCardPlayerB != 14))
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    Environment.Exit(0);
                }
                if ((firstCardPlayerA != 14 && secondCardPlayerA != 14 && thirdCardPlayerA != 14) && (firstCardPlayerB == 14 ||
                    secondCardPlayerB == 14 || thirdCardPlayerB == 14))
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    Environment.Exit(0);
                }
                if ((firstCardPlayerA == 14 || secondCardPlayerA == 14 || thirdCardPlayerA == 14) && (firstCardPlayerB == 14 ||
                    secondCardPlayerB == 14 || thirdCardPlayerB == 14))
                {
                    resultA += 50;
                    resultB += 50;
                }

                if (playerAscore > playerBscore)
                {
                    resultA += playerAscore;
                    gamesWonA++;
                }
                if (playerBscore > playerAscore)
                {
                    resultB += playerBscore;
                    gamesWonB++;
                }

            }
        }

        if (resultA == resultB)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", resultA + resultB);
        }
        if (resultA > resultB)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", resultA);
            Console.WriteLine("Games won: {0}", gamesWonA);
        }
        if (resultA < resultB)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", resultB);
            Console.WriteLine("Games won: {0}", gamesWonB);
        }
    }
}

