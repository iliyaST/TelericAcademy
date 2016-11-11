using System;

class MagicalNumbers
{
    static void Trick(int number)
    {
        int firstDigit = number / 100 % 10;
        int secondDigit = number / 10 % 10;
        int thirdDigit = number % 10;
        double result = 0;

        if (secondDigit % 2 == 0)
        {
            result = (firstDigit + secondDigit) * thirdDigit;
        }
        else
        {
            result = (firstDigit * secondDigit) / (double)thirdDigit;
        }

        Console.WriteLine("{0:F2}", result);
    }

    static void Main()
    {
        int inputNumber = int.Parse(Console.ReadLine());

        Trick(inputNumber);
    }
}

