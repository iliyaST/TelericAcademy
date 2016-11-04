using System;

class EnglishDigit
{
    static string LastDigitAsWord(int number)
    {
        int lastDigit = number % 10;
        string result = "";

        switch (lastDigit)
        {
            case 0:  result = "zero"; break;
            case 1: result = "one"; break;
            case 2: result = "two"; break;
            case 3: result = "three"; break;
            case 4: result = "four"; break;
            case 5: result = "five"; break;
            case 6: result = "six"; break;
            case 7: result = "seven"; break;
            case 8: result = "eight"; break;
            case 9: result = "nine"; break;
            default: result = "zero"; break;
        }
        return result;
    }

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        string lastDigit = LastDigitAsWord(number);

        Console.WriteLine(lastDigit);
    }
}

