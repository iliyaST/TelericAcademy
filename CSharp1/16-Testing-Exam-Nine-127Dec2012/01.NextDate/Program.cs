using System;

class NextDate
{
    static void Main()
    {
        int dayUser = int.Parse(Console.ReadLine());
        int monthUser = int.Parse(Console.ReadLine());
        int yearUser = int.Parse(Console.ReadLine());

        DateTime date = new DateTime(yearUser, monthUser, dayUser);

        DateTime newDay = date.AddDays(1);
       
        Console.WriteLine("{0}.{1}.{2}",newDay.Day,newDay.Month,newDay.Year);
    }
}

