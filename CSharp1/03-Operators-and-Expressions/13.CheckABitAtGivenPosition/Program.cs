using System;
/*
Problem 13. Check a Bit at Given Position
Write a Boolean expression that returns if the bit at position 
p (counting from 0, starting from the right) in given integer number n, has value of 1.
*/
class CheckABitAtGivenPosition
{
    static void Main()
    {
        long unsignedInteger = long.Parse(Console.ReadLine());
        int givenIndex = int.Parse(Console.ReadLine());

        long mask = 1 << givenIndex;
        long nAndMask = unsignedInteger & mask;
        bool bit = nAndMask >> givenIndex == 1;

        string result = bit.ToString().ToLower();

        Console.WriteLine(result);
    }
}

