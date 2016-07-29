using System;
/*
Problem 9. Play with Int, Double and String
Write a program that, depending on the user’s choice, inputs an int, double or string variable.
If the variable is int or double, the program increases it by one.
If the variable is a string, the program appends * at the end.
Print the result at the console. Use switch statement.
*/
class IntDoubleString
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (input == "integer")
        {
            int integer = int.Parse(Console.ReadLine());
            Console.WriteLine(++integer);
        }
        if (input == "real")
        {
            double realNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:0.00}", ++realNumber);
        }
        if (input == "text")
        {
            string text = Console.ReadLine();
            Console.WriteLine("{0}*", text);
        }
    }
}

