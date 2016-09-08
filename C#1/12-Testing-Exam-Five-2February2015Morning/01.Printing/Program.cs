using System;
using System.IO;

class Printing
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../testInput.txt");
        Console.SetIn(sr);

        int numberOfStudents = int.Parse(Console.ReadLine());
        int papersForStudent = int.Parse(Console.ReadLine());
        decimal priceOfRealm = decimal.Parse(Console.ReadLine());

        int totalPapers = numberOfStudents * papersForStudent;
        decimal amountOfRealms = (decimal)totalPapers / 500;
        decimal amountMoney = (decimal)(amountOfRealms * priceOfRealm);

        Console.WriteLine("{0:F2}",amountMoney);
    }
}

