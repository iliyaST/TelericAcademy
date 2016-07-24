using System;
/*
Problem 9. Print a Sequence
Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
*/
class PrintSequence
{
    static void Main()
    {
        int member = 2;
        for (int i = 0; i < 10; i++)
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
