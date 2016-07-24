using System;
/*
Problem 12. Extract Bit from Integer
Write an expression that extracts from given integer n the value of given bit at index p.
*/
class ExtractBitFromInteger
{
    static void Main()
    {
        long unsignedInteger = long.Parse(Console.ReadLine());
        int givenIndex = int.Parse(Console.ReadLine());

        long mask = 1 << givenIndex;
        long nAndMask = unsignedInteger & mask;
        long bit = nAndMask >> givenIndex;

        Console.WriteLine(bit);
    }
}

