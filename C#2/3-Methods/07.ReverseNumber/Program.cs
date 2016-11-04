using System;
using System.Collections.Generic;

class ReverseNumber
{
    static string ReverseTheNumber(string number)
    {       
        string reversed = "";

        for (int i = number.Length-1; i >= 0; i--)
        {
            reversed += number[i];
        }

        return reversed;
    }

    static void Main()
    {
        string someNumber = Console.ReadLine();
        string reversedNumber = "";

        reversedNumber = ReverseTheNumber(someNumber);

        Console.WriteLine(reversedNumber);
    }
}

