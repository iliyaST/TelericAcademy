using System;
using System.Numerics;
/*
Problem 10. Odd and Even Product
You are given n integers (given in a single line, separated by a space).
Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
*/
class OddOrEvenProduct
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());        
        BigInteger productValue = 1;
        BigInteger oddProductValue = 1;
        int counter = 2;
        int oddCounter = 0;
        string temp = Console.ReadLine();
        int index = temp.IndexOf(' ');

        if (n <= 1)
        {
            productValue *= (Convert.ToInt32(temp.ToString()));
            Console.WriteLine("no {0}", productValue);
            Environment.Exit(0);
        }
        while (counter < n * 2)
        {

            productValue *= Convert.ToInt32(temp.Substring(counter, index));
            counter += 4;
        }
        while (oddCounter < n * 2)
        {

            oddProductValue *= Convert.ToInt32(temp.Substring(oddCounter, index));
            oddCounter += 4;
        }


        if (productValue == oddProductValue)
        {
            Console.WriteLine("yes {0}", productValue);
        }
        else
        {
            Console.WriteLine("no {0} {1}", oddProductValue, productValue);
        }
    }
}

