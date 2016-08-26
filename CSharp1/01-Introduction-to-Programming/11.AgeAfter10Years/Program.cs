using System;
/*
Problem 15.* Age after 10 Years
Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years. 
*/
class Ageafter10Years
{
    static void Main()
    {
        Console.WriteLine("Enter your birthday(yyy.m.d)");
        DateTime birthday = DateTime.Parse(Console.ReadLine());
        DateTime today = DateTime.Now;
        int age = today.Year - birthday.Year;
        if ((birthday.Month <= today.Month && birthday.Day <= today.Day) ^ (birthday.Month < today.Month && birthday.Day > today.Day))
        {
            Console.WriteLine("You are {0} years old.", age);
            Console.WriteLine("After 10 years you will be {0} years old", age + 10);
        }
        else
        {
            Console.WriteLine("You are {0} years old.", age - 1);
            Console.WriteLine("After 10 years you will be {0} years old", age + 9);
        }
    }
}
