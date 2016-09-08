using System;

class AngryFemaleGPS
{
    static void Main()
    {
        string randomNumber = Console.ReadLine();
        long number = long.Parse(randomNumber);
        int evenSum = 0;
        int oddSum = 0;
        int counter = 0;

        if(number<0)
        {
            number = -number;
            randomNumber = number.ToString();
        }
        
        foreach (char digit in randomNumber)
        {
            if (counter % 2 == 0)
            {
                evenSum += digit - '0';
            }
            else
            {
                oddSum += digit - '0';
            }
            counter++;
        }

        if (evenSum > oddSum)
        {
            Console.WriteLine("right {0}", evenSum);
        }
        if (evenSum < oddSum)
        {
            Console.WriteLine("left {0}", oddSum);
        }
        if (evenSum == oddSum)
        {
            Console.WriteLine("straight {0}", evenSum);
        }

    }
}

