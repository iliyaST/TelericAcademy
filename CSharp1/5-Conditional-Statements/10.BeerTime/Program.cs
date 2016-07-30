using System;
using System.Globalization;
/*
Problem 10.* Beer Time
A beer time is after 1:00 PM and before 3:00 AM.
Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12],
a minute in range [00…59] and AM / PM designator) and prints beer time or non-beer
time according to the definition above or invalid time if the time cannot be parsed. Note: 
You may need to learn how to parse dates and times. 
*/
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        DateTime inputedTime;


        if (DateTime.TryParse(input, out inputedTime))
        {
            DateTime after = DateTime.Parse("1:00 AM");
            DateTime before = DateTime.Parse("3:00 PM");
            if ((inputedTime > after) && (inputedTime < before))
            {
                Console.WriteLine("bear time");
            }
            else
            {
                Console.WriteLine("non-bear time");
            }
        }
        else
        {
            Console.WriteLine("rong input");
        }
    }
}
