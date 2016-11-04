using System;

class GetLargestNumber
{
    static int GetMax(int firstNumber, int secondNumber)
    {
        if (firstNumber > secondNumber)
        {
            return firstNumber;
        }
        else if (firstNumber < secondNumber)
        {
            return secondNumber;
        }
        else
        {
            return firstNumber;
        }
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' });

        int firstNumber = int.Parse(input[0]);
        int secondNumber = int.Parse(input[1]);
        int thirdNumber = int.Parse(input[2]);
        int max = 0;

        max = GetMax(firstNumber, secondNumber);
        max = GetMax(max, thirdNumber);

        Console.WriteLine(max);
    }
}

