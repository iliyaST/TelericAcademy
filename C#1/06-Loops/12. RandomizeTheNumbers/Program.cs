using System;
/*
Problem 12.* Randomize the Numbers 1…N
Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
Note: The above output is just an example. 
Due to randomness, your program most probably will produce different results. You might need to use arrays.
*/
class RandomizeTheNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array;
        array = new int[n + 1];
        Random rand = new Random();

        for (int i = 1; i <= n; i++)
        {
            array[i] = rand.Next(1, n + 1);
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();

    }
}

