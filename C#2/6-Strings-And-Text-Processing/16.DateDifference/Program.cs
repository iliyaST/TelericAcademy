using System;

class DateDifference
{
    static void Main()
    {
        int days = 0;

        Console.WriteLine("Enter the first date:");

        Console.WriteLine("Enter a day of the month:");
        int day = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a month of the year:");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a year:");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second Date");

        string[] input = Console.ReadLine().Split(new char[] { '.' },
            StringSplitOptions.RemoveEmptyEntries);

        int otherDateDay = int.Parse(input[0]);
        int otherDateMonth = int.Parse(input[1]);
        int otherDateYear = int.Parse(input[2]);

        DateTime currentDate = new DateTime(year, month, day);
        DateTime otherDate = new DateTime(otherDateYear, otherDateMonth, otherDateDay);
        DateTime i = currentDate;

        while (i != otherDate)
        {
            i = i.AddDays(1);
            days++;
        }

        Console.WriteLine("Distance: {0} days",days);

    }
}

