using System;
using System.Numerics;
class QuadronacciRectangle
{
    static void Main()
    {
        BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger seconNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger fourthNumber = BigInteger.Parse(Console.ReadLine());
        int numberOfLines = int.Parse(Console.ReadLine());
        int numbersPerLine = int.Parse(Console.ReadLine());
        int counter = 0;
        BigInteger temp1 = 0;
        BigInteger temp2 = 0;
        BigInteger temp3 = 0;


        Console.Write(firstNumber + " ");
        Console.Write(seconNumber + " ");
        Console.Write(thirdNumber + " ");
        Console.Write(fourthNumber + " ");
        counter = 4;

        for (int i = 0; i < (numberOfLines * numbersPerLine) - 4; i++)
        {
            if (counter == numbersPerLine)
            {
                Console.WriteLine();
                counter = 0;
            }
            temp1 = firstNumber + seconNumber + thirdNumber + fourthNumber;
            firstNumber = seconNumber;
            seconNumber = thirdNumber;
            thirdNumber = fourthNumber;
            fourthNumber = temp1;
            Console.Write(fourthNumber + " ");           
            counter++;
        }
        Console.WriteLine();
    }
}

