using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        int numberOfRounds = int.Parse(Console.ReadLine());
        int zCounterA = 1;
        int zCounterB = 1;
        int yCounterA = 0;
        int yCounterB = 0;
        int firstCardA = 0;
        int secondCardA = 0;
        int thirdCardA = 0;
        int firstCardB = 0;
        int secondCardB = 0;
        int thirdCardB = 0;
        BigInteger currentScoreA = 0;
        BigInteger currentScoreB = 0;
        bool isXA = false;
        bool isYA = false;
        bool isZA = false;
        bool isXB = false;
        bool isYB = false;
        bool isZB = false;
        int gamesWonA = 0;
        int gamesWonB = 0;
        BigInteger finalResultA = 0;
        BigInteger finalResultB = 0;

        for (int i = 0; i < numberOfRounds; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                string temp = Console.ReadLine();
                #region Temp rename
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
                    case "X":
                        if (j > 2)
                        {
                            isXB = true;
                        }
                        else
                        {
                            isXA = true;
                        }
                        temp = "0";
                        break;
                    case "Y":
                        if (j > 2)
                        {
                            yCounterB++;
                            isYB = true;
                        }
                        else
                        {
                            yCounterA++;
                            isYA = true;
                        }
                        temp = "0";
                        break;
                    case "Z":
                        if (j > 2)
                        {
                            zCounterB *= 2;
                            isZB = true;
                        }
                        else
                        {
                            zCounterA *= 2;
                            isZA = true;
                        }
                        temp = "0";
                        break;
                }
                #endregion
                #region cards
                if (j == 0)
                {
                    firstCardA = int.Parse(temp);
                    continue;
                }
                if (j == 1)
                {
                    secondCardA = int.Parse(temp);
                    continue;
                }
                if (j == 2)
                {
                    thirdCardA = int.Parse(temp);
                    continue;
                }
                if (j == 3)
                {
                    firstCardB = int.Parse(temp);
                    continue;
                }
                if (j == 4)
                {
                    secondCardB = int.Parse(temp);
                    continue;
                }
                if (j == 5)
                {
                    thirdCardB = int.Parse(temp);
                    currentScoreA += firstCardA + secondCardA + thirdCardA;
                    currentScoreB += firstCardB + secondCardB + thirdCardB;

                    if (isXA == true && isXB == false)
                    {
                        Console.WriteLine("X card drawn! Player one wins the match!");
                        Environment.Exit(0);
                    }
                    if (isXA == false && isXB == true)
                    {
                        Console.WriteLine("X card drawn! Player two wins the match!");
                        Environment.Exit(0);
                    }
                    if (isZA == true)
                    {
                        finalResultA *= zCounterA;
                        isZA = false;
                        zCounterA = 1;
                    }
                    if (isZB == true)
                    {
                        finalResultB *= zCounterB;
                        isZB = false;
                        zCounterB = 1;
                    }
                    if (isXA == true && isXA == true)
                    {

                        if (currentScoreA > currentScoreB)
                        {
                            gamesWonA++;
                        }
                        if (currentScoreB > currentScoreA)
                        {
                            gamesWonB++;
                        }
                        if (i < numberOfRounds - 1)
                        {
                            finalResultA += 50;
                            finalResultB += 50;
                        }
                        else
                        {
                            finalResultA += 50 + currentScoreA;
                            finalResultB += 50 + currentScoreB;
                        }
                        isXA = false;
                        isXB = false;
                        currentScoreA = 0;
                        currentScoreB = 0;
                    }
                    if (isYA == true)
                    {
                        finalResultA += (-200 * yCounterA);
                        isYA = false;
                        yCounterA = 0;
                    }
                    if (isYB == true)
                    {
                        finalResultB += (-200 * yCounterB);
                        isYB = false;
                        yCounterB = 0;
                    }
                    if (currentScoreA > currentScoreB)
                    {
                        finalResultA += currentScoreA;
                        gamesWonA++;
                    }
                    if (currentScoreB > currentScoreA)
                    {
                        finalResultB += currentScoreB;
                        gamesWonB++;
                    }
                    currentScoreA = 0;
                    currentScoreB = 0;
                }
                #endregion      
            }
        }
        if (finalResultA == finalResultB)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", finalResultB);
        }
        if (finalResultB > finalResultA)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", finalResultB);
            Console.WriteLine("Games won: {0}", gamesWonB);
        }
        if (finalResultA > finalResultB)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", finalResultA);
            Console.WriteLine("Games won: {0}", gamesWonA);
        }

    }
}

