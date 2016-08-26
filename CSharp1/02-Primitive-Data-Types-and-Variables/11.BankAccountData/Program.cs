using System;
/*
Problem 11. Bank Account Data
A bank account has a holder name (first name, middle name and last name), 
available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
Declare the variables needed to keep the information for a single bank account using the appropriate data 
types and descriptive names.
*/
class BankAccountData
{
    static void Main()
    {
        Console.WriteLine("Insert first name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Insert midd name:");
        string middName = Console.ReadLine();
        Console.WriteLine("Insert last name:");
        string lastName = Console.ReadLine();
        decimal balance = 100000;
        string BankName = "First Investion Bank";
        string IBAN = "BG80 BNBG 9661 1020 3456 78";
        string CreditCardNum1 = "Visa: 4111 1111 1111 1111";
        string CreditCardNum2 = "Master card: 5500 0000 0000 0004";
        string CreditCardNum3 = "American express: 3400 0000 0000 009";
        Console.WriteLine(firstName);
        Console.WriteLine(middName);
        Console.WriteLine(lastName);
        Console.WriteLine("balance: " + balance);
        Console.WriteLine("Bank: " + BankName);
        Console.WriteLine("IBAN: " + IBAN);
        Console.WriteLine(CreditCardNum1);
        Console.WriteLine(CreditCardNum2);
        Console.WriteLine(CreditCardNum3);

    }
}

