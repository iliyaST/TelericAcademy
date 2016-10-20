using System;

class Combintions
{
    static int iterations;
    static int numberOfElements;
    static int[] array;

    static void Main()
    {
        iterations = int.Parse(Console.ReadLine());
        numberOfElements = int.Parse(Console.ReadLine());
        array = new int[numberOfElements];
        allCombinations(0, 1, iterations);
    }

    public static void allCombinations(int c, int start, int end)
    {
        if (c == numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
            return;
        }

        for (int counter = start; counter <= end; counter++)
        {
            array[c] = counter;
            allCombinations(c + 1, counter+1, end);
        }
    }
}

