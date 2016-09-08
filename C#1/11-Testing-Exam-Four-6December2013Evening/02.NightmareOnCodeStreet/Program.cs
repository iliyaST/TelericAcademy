using System;
using System.Numerics;
class NightmareOnCodeStreet
{
    static void Main()
    {
        string input = Console.ReadLine();
        int digitInt;
        int counter = 0;
        long sumOfOddDigits = 0;
        int counterOfOddDigits = 0;

        foreach (char digit in input)
        {
            if (('0' <= digit && digit <= '9')&&(counter%2!=0))
            {
                sumOfOddDigits += digit - '0';
            }
            if (counter % 2 != 0)
            {
                counterOfOddDigits++;      
            }
            counter++;
            Console.WriteLine(counter);
        }

        Console.WriteLine("{0} {1}", counterOfOddDigits, sumOfOddDigits);
    }
}

