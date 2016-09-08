using System;
/*
Problem 14. Modify a Bit at Given Position
We are given an integer number n, a bit value v (v=0 or 1) and a position p.
Write a sequence of operators (a few lines of C# code) that modifies n 
to hold the value v at the position p from the binary representation of n while preserving all other bits in n.
*/
class ModifyBit
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        long result = number;
        int p = int.Parse(Console.ReadLine());
        byte valueV = byte.Parse(Console.ReadLine());
       
        if(valueV == 1)
        {
            result = number | (1 << p);
        }
        else
        {
            result = number & ~(1 << p);
        }

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
        Console.WriteLine(Convert.ToString(result, 2).PadLeft(16, '0'));


    }
}

