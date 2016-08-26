using System;
/*
Problem 2. Bonus Score
Write a program that applies bonus score to given score in the range [1…9] by the following rules:
If the score is between 1 and 3, the program multiplies it by 10.
If the score is between 4 and 6, the program multiplies it by 100.
If the score is between 7 and 9, the program multiplies it by 1000.
If the score is 0 or more than 9, the program prints “invalid score”.
*/
class BonusScore
{
    static void Main()
    {
        int givenScore = int.Parse(Console.ReadLine());

        if (1 <= givenScore && givenScore <= 3)
        {
            givenScore *= 10;
            Console.WriteLine(givenScore);
        }
        else if (givenScore <= 6 && givenScore >= 1)
        {
            givenScore *= 100;
            Console.WriteLine(givenScore);
        }
        else if (7 <= givenScore && givenScore <= 9)
        {
            givenScore *= 1000;
            Console.WriteLine(givenScore);
        }
        else
        {
            Console.WriteLine("invalid score");
        }
    }
}

