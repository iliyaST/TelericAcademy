using System;
/*
Problem 2. Print Company Information
A company has name, address, phone number, fax number, web site and manager. The manager has first name, 
last name, age and a phone number.
Write a program that reads the information about a company and its manager and prints it back on the console. 
*/
class CompanyInfo
{
    static void Main()
    {
        string companyName = Console.ReadLine();
        string companyAdress = Console.ReadLine();
        string phoneNumber = Console.ReadLine();
        string faxNumber = Console.ReadLine();
        string webSite = Console.ReadLine();
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        byte managerAge = byte.Parse(Console.ReadLine());
        string managerNumber = Console.ReadLine();

        Console.WriteLine(companyName);
        Console.WriteLine("Address: " + companyAdress);
        Console.WriteLine("Tel. " + phoneNumber);
        if (faxNumber == "")
        {
            Console.WriteLine("Fax: (no fax)");
        }
        if (managerAge <= 0)
        {
            Console.WriteLine("Rong input!");
        }
        else
        {
            Console.WriteLine("Web site: " + webSite);
            Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", firstName, lastName, managerAge, managerNumber);
        }
    }
}

