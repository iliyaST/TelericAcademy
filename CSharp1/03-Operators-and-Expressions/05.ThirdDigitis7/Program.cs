using System;
/*
Write an expression that checks for given integer if its third digit from right-to-left is 7. 
*/
class ThirdDigits7
{
    static void Main()
    {
        int givenInteger = int.Parse(Console.ReadLine());
        bool is7TheThirdDigit = (givenInteger / 100) % 10 == 7;

        string result = is7TheThirdDigit.ToString().ToLower();

        if (result == "true")
        {
            Console.WriteLine("{0} ", result);
        }
        else
        {
            Console.WriteLine("{0} {1}", result, (givenInteger / 100) % 10);
        }
    }
}

