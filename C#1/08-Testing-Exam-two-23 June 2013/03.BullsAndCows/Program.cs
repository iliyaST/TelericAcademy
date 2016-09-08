using System;

class BullsAndCows
{
    static void Main()
    {
        int secretNumber = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        bool isTrue = false;

        for (int i = 1000; i <= 9999; i++)
        {
            int currentBulls = 0;
            int currentCows = 0;
            #region find digits of i
            int currentNumber = i;
            int currentNumberD = currentNumber % 10;
            currentNumber /= 10;
            int currentNumberC = currentNumber % 10;
            currentNumber /= 10;
            int currentNumberB = currentNumber % 10;
            currentNumber /= 10;
            int currentNumberA = currentNumber % 10;
            #endregion
            if (currentNumberA == 0 || currentNumberB == 0 || currentNumberC == 0 || currentNumberD == 0)
            {
                continue;
            }
            #region find digits of secretNumber
            int guessNumber = secretNumber;
            int guessNumberD = guessNumber % 10;
            guessNumber /= 10;
            int guessNumberC = guessNumber % 10;
            guessNumber /= 10;
            int guessNumberB = guessNumber % 10;
            guessNumber /= 10;
            int guessNumberA = guessNumber % 10;
            #endregion
            #region how many bulls 
            if (currentNumberA == guessNumberA)
            {
                currentBulls++;
                currentNumberA = -1;
                guessNumberA = -2;
            }
            if (currentNumberB == guessNumberB)
            {
                currentBulls++;
                currentNumberB = -1;
                guessNumberB = -2;
            }
            if (currentNumberC == guessNumberC)
            {
                currentBulls++;
                currentNumberC = -1;
                guessNumberC = -2;
            }
            if (currentNumberD == guessNumberD)
            {
                currentBulls++;
                currentNumberD = -1;
                guessNumberD = -2;
            }
            #endregion
            #region how many cows

            if (currentNumberA == guessNumberB)
            {
                currentCows++;
                currentNumberA = -1;
                guessNumberB = -2;
            }
            if (currentNumberA == guessNumberC)
            {
                currentCows++;
                currentNumberA = -1;
                guessNumberC = -2;
            }
            if (currentNumberA == guessNumberD)
            {
                currentCows++;
                currentNumberA = -1;
                guessNumberD = -2;
            }
            if (currentNumberB == guessNumberA)
            {
                currentCows++;
                currentNumberB = -1;
                guessNumberA = -2;
            }
            if (currentNumberB == guessNumberC)
            {
                currentCows++;
                currentNumberB = -1;
                guessNumberC = -2;
            }
            if (currentNumberB == guessNumberD)
            {
                currentCows++;
                currentNumberB = -1;
                guessNumberD = -2;
            }
            if (currentNumberC == guessNumberA)
            {
                currentCows++;
                currentNumberC = -1;
                guessNumberA = -2;
            }
            if (currentNumberC == guessNumberB)
            {
                currentCows++;
                currentNumberC = -1;
                guessNumberB = -2;
            }
            if (currentNumberC == guessNumberD)
            {
                currentCows++;
                currentNumberC = -1;
                guessNumberD = -2;
            }
            if (currentNumberD == guessNumberA)
            {
                currentCows++;
                currentNumberD = -1;
                guessNumberA = -2;
            }
            if (currentNumberD == guessNumberB)
            {
                currentCows++;
                currentNumberD = -1;
                guessNumberB = -2;
            }
            if (currentNumberD == guessNumberC)
            {
                currentCows++;
                currentNumberD = -1;
                guessNumberC = -2;
            }
            #endregion
            if (currentBulls == bulls && currentCows == cows)
            {
                isTrue = true;
                Console.Write("{0} ", i);
            }
        }
        if (isTrue == false)
        {
            Console.WriteLine("No");
        }
    }
}

