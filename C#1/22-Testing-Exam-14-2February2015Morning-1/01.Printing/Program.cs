using System;

class Printing
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int S = int.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());

        int numberOfSheets = N * S;
        double realms = numberOfSheets / 500.0;
        double totalPriceRealms = realms * P;

        Console.WriteLine("{0:F2}", totalPriceRealms);
    }
}

