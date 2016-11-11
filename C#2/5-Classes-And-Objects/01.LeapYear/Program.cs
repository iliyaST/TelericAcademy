using System;

class LeapYear
{
    static string checkYear(DateTime date)
    {
        if (DateTime.IsLeapYear(date.Year))
        {
            return "Leap";
        }
        else
        {
            return "Common";
        }

    }

    static void Main()
    {
        int year = int.Parse(Console.ReadLine());

        DateTime currentYear = new DateTime(year, 1, 1);

        string result = checkYear(currentYear);

        Console.WriteLine(result);
    }
}

