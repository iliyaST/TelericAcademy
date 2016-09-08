using System;

class SevenlandNumbers
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        int newInput = 0;

        if (input <= 9)
        {
            if (input < 6)
            {
                newInput = input + 1;
            }
            else if (input == 6)
            {
                newInput = 10;
            }
        }
        if (input > 9 && input < 100)
        {
            if (input % 10 < 6)
            {
                newInput = input + 1;
            }
            else
            {
                if (input / 10 < 6 && (input%10==6))
                {
                    newInput = input + 4;
                }
                else if(input / 10 >= 6 && (input % 10 == 6))
                {
                    newInput = 100;
                }
            }
        }
        if (input > 99)
        {
            if (input % 10 != 6)
            {
                newInput = input + 1;
            }
            else
            {
                if ((input / 10) % 10 < 6 && ((input / 100) % 10 < 6))
                {
                    newInput = input + 4;
                }
                if (((input / 10) % 10 >= 6 && ((input / 100) % 10 < 6)))
                {
                    newInput = (((input / 100) % 10) + 1) * 100;
                }
                if (((input / 10) % 10 >= 6) && ((input / 100) % 10 >= 6))
                {
                    newInput = 1000;
                }
                if (((input / 10) % 10 < 6) && ((input / 100) % 10 >= 6))
                {
                    newInput = input + 4;
                }
            }
        }
        Console.WriteLine(newInput);
    }
}

