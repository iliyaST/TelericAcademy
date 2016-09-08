using System;
using System.Numerics;

class CardWarsOther
{
    static void Main()
    {
        int numberOfRounds = int.Parse(Console.ReadLine());
        BigInteger finalResultA = 0;
        BigInteger finalResultB = 0;
        BigInteger currentResultA = 0;
        BigInteger currentResultB = 0;
        bool isXA = false;
        bool isXB = false;
        int firstCardA = 0;
        int secondCardA = 0;
        int thirdCardA = 0;
        int firstCardB = 0;
        int secondCardB = 0;
        int thirdCardB = 0;
        int roundsWonA = 0;
        int roundsWonB = 0;

        for (int i = 0; i < numberOfRounds; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                string temp = Console.ReadLine();
                switch (temp)
                {
                    case "2": temp = "10"; break;
                    case "3": temp = "9"; break;
                    case "4": temp = "8"; break;
                    case "5": temp = "7"; break;
                    case "6": temp = "6"; break;
                    case "7": temp = "5"; break;
                    case "8": temp = "4"; break;
                    case "9": temp = "3"; break;
                    case "10": temp = "2"; break;
                    case "A": temp = "1"; break;
                    case "J": temp = "11"; break;
                    case "Q": temp = "12"; break;
                    case "K": temp = "13"; break;
                    case "X":
                        {
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
                        }
                    case "Z":
                        {
                            if (j > 2)
                            {
                                finalResultB *= 2;
                            }
                            else
                            {
                                finalResultA *= 2;
                            }
                            temp = "0";
                            break;
                        }
                    case "Y":
                        {
                            if (j > 2)
                            {
                                finalResultB -= 200;
                            }
                            else
                            {
                                finalResultA -= 200;
                            }
                            temp = "0";
                            break;
                        }
                }
                if (j == 0) { firstCardA = int.Parse(temp); }
                if (j == 1) { secondCardA = int.Parse(temp); }
                if (j == 2) { thirdCardA = int.Parse(temp); }
                if (j == 3) { firstCardB = int.Parse(temp); }
                if (j == 4) { secondCardB = int.Parse(temp); }
                if (j == 5)
                {
                    thirdCardB = int.Parse(temp);
                    currentResultA = firstCardA + secondCardA + thirdCardA;
                    currentResultB = firstCardB + secondCardB + thirdCardB;
                    if (isXA == true && isXB == true)
                    {
                        finalResultA += 50;
                        finalResultB += 50;
                        isXA = false;
                        isXB = false;
                    }
                    if (currentResultA > currentResultB)
                    {
                        finalResultA += currentResultA;
                        roundsWonA++;
                    }
                    else if (currentResultB > currentResultA)
                    {
                        finalResultB += currentResultB;
                        roundsWonB++;
                    }
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
                }

            }
        }
        if (finalResultA > finalResultB)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", finalResultA);
            Console.WriteLine("Games won {0}", roundsWonA);
        }
        if (finalResultA < finalResultB)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", finalResultB);
            Console.WriteLine("Games won {0}", roundsWonB);
        }
        if (finalResultA == finalResultB)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", finalResultB);

        }
    }
}


