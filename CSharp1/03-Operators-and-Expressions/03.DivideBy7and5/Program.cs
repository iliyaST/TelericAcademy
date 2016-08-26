using System;
/*
Problem 3. Divide by 7 and 5
Write a Boolean expression that checks for given integer 
if it can be divided (without remainder) by 7 and 5 at the same time.
*/
class DivideBy7And5
{
    static void Main()
    {
        int integer = int.Parse(Console.ReadLine());
        bool first = integer % 7 == 0;
        bool second = integer % 5 == 0;
        bool result = first && second;
        Console.WriteLine(result.ToString().ToLower()+" "+integer);
        
    }
}

