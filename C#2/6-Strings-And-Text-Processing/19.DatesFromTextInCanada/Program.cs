using System;
using System.Globalization;
using System.Text.RegularExpressions;

class DatesFromTextInCanada
{
    static void Main()
    {
        string randomText = Console.ReadLine();

        foreach (Match item in Regex.Matches(randomText, @"\b[0-9]{1,2}.[0-9]{1,2}.[0-9]{2,4}"))
        {
            DateTime date;

            if (DateTime.TryParseExact(item.Value, "d.M.yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out date))
            {
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }
        Console.WriteLine();
    }
}

