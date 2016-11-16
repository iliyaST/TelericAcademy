using System;
using System.Text.RegularExpressions;

class ExtractEMails
{
    static void Main()
    {
        string text = Console.ReadLine();

        string[] emails = text.Split(new[] { " ", ";", ",", ". " },
            StringSplitOptions.RemoveEmptyEntries);

        string[] validEmails = Array.FindAll(emails, IsValidEmail);

        Print(validEmails);
    }
    static bool IsValidEmail(string emailAddress)
    {
        const string regexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        Match matches = Regex.Match(emailAddress, regexPattern);
        return matches.Success;
    }
    static void Print(string[] validEmails)
    {
        foreach (var email in validEmails)
        {
            Console.WriteLine(email);
        }
        Console.WriteLine();
    }
}

