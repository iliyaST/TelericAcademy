using System;
/*
Problem 16.* Print Long Sequence
Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
You might need to learn how to use loops in C# (search in Internet).
*/
class PrintLongSequence
{
    static void Main()
    {
        int member = 2;
        for (int i = 0; i < 1000; i++)
        {
            if (member % 2 == 0)
            {
                Console.WriteLine(member);
                member++;
            }
            else
            {
                Console.WriteLine(-member);
                member++;
            }

        }
    }
}