using System;
/*
Problem 10. Employee Data
A marketing company wants to keep record of its employees. Each record would have the following characteristics:
First name
Last name
Age (0...100)
Gender (m or f)
Personal ID number (e.g. 8306112507)
Unique employee number (27560000…27569999)
Declare the variables needed to keep the information for a single employee using appropriate 
primitive data types. Use descriptive names. Print the data at the console.
*/
class EmployeeData
{
    static void Main()
    {
        Console.WriteLine("First Name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Last Name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Age: ");
        string Age = Console.ReadLine();
        Console.WriteLine("Male/Female");
        string Gender = Console.ReadLine();
        Console.WriteLine("ID: 10letters(e.g. 8306112507):");
        string ID = Console.ReadLine();
        Console.WriteLine("Unique Numeber(27560000…27569999):");
        string UniqueNumber = Console.ReadLine();
        Console.WriteLine(firstName);
        Console.WriteLine(lastName);
        Console.WriteLine(Age);
        Console.WriteLine(Gender);
        Console.WriteLine(ID);
        Console.WriteLine(UniqueNumber);


    }
}

