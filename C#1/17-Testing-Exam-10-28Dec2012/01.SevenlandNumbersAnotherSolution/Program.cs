using System;


class SevenLandOtherSolution
{
    static void Main()
    {

        int input = int.Parse(Console.ReadLine());
        int decimalNumber = 0;
        int pow = 0;
        int result = 0;
        int counter = 1;
        //convert from 7th base to Decimal 
        while (input != 0)
        {
            decimalNumber += input % 10 * (int)Math.Pow(7, pow);
            input /= 10;
            pow++;
        }

        decimalNumber++;

        //convert from decimal to 7th base
        while (decimalNumber != 0)
        {
            result += decimalNumber % 7 * counter;           
            decimalNumber /= 7;
            counter *= 10;
        }

        Console.WriteLine(result);
    }
}


