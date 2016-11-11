using System;

class Workdays
{
    static DateTime[] holydays = new DateTime[]
    {
        new DateTime(2016,11,11),
        new DateTime(2016,12,24),
        new DateTime(2016,12,25),
        new DateTime(2017,1,1)
    };

    static bool isHolyday(DateTime date)
    {
        foreach (var day in holydays)
        {
            if (day == date)
            {
                return true;
            }
        }
        return false;
    }

    static void FindWorkDays(DateTime endDate)
    {
        int workDays = 0;
        DateTime now = DateTime.Now;

        for (DateTime i = now.Date; i <= endDate; i = i.AddDays(1))
        {
            if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
            {
                continue;
            }
            else if(isHolyday(i))
            {
                continue;
            }
            else
            {
                workDays++;
            }
            //Console.Write(workDays + " ");
        }
        Console.WriteLine(workDays);
    }

    static void Main()
    {
        Console.WriteLine("Enter year");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter month");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter day");
        int day = int.Parse(Console.ReadLine());

        DateTime endDate = new DateTime(year, month, day);

        FindWorkDays(endDate);
    }
}

