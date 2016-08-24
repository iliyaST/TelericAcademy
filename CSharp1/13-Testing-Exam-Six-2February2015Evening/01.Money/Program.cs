using System;

class Money
{
    static void Main()
    {
        int numberOfStudents = int.Parse(Console.ReadLine());
        int papersPerStudent = int.Parse(Console.ReadLine());
        decimal priceOfRealm = decimal.Parse(Console.ReadLine());

        long totalAmountOfPaper = numberOfStudents * papersPerStudent;
        decimal numberOfReamls = (decimal)totalAmountOfPaper / 400;
        decimal moneyBeingSaved = numberOfReamls * priceOfRealm;

        Console.WriteLine("{0:F3}", moneyBeingSaved);

    }
}

