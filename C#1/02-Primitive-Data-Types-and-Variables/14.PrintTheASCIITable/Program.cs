using System;
using System.Text;
/*
Problem 14.* Print the ASCII Table
Find online more information about ASCII (American Standard Code for Information Interchange) 
and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).
Note: Some characters have a special purpose and will not be displayed as expected. 
You may skip them or display them differently.
Note: You may need to use for-loops (learn in Internet how). 
*/
class PrinttheASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        char symbol;
        for (int i = 33; i < 127; i++)
        {
            symbol = (char)i;
            Console.Write(symbol);
        }

    }
}

