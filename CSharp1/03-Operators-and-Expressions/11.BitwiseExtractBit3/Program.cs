using System;
/*
Problem 11. Bitwise: Extract Bit #3
Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
The bits are counted from right to left, starting from bit #0.
The result of the expression should be either 1 or 0.
*/
class ExtractBit3
{
    static void Main()
    {
        int unsignedInteger = int.Parse(Console.ReadLine());

        int p = 3;
        int mask = 1 << p;
        int nAndMask = unsignedInteger & mask;
        int bit = nAndMask >> 3;

        Console.WriteLine(bit);
    }
}

