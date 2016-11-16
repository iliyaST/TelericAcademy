using System;
using System.Globalization;
using System.Text;
using System.Threading;

class DateInBulgarian
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        string date = Console.ReadLine();
        DateTime currentDate = DateTime.ParseExact(date,"d.M.yyyy.h.m.ss",CultureInfo.InvariantCulture);
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        Console.WriteLine("Часът сега е:");
        Console.WriteLine(currentDate);

        Console.WriteLine("След 6часа и 30 мин ще бъде");
        DateTime dateAfterTime = currentDate.AddHours(6).AddMinutes(30);

        Console.WriteLine(dateAfterTime);
    }
}

