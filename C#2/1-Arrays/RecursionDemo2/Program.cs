using System;

class RecursiveNestedLoops
{
    static int numberOfLoops;
    static int numberOfIterations;
    static int[] loops;

    static void Main()
    {
        numberOfLoops = int.Parse(Console.ReadLine());
        numberOfIterations = numberOfLoops;
        loops = new int[numberOfIterations];
        nestedLoops(0);
    }

    static void nestedLoops(int counter)
    {
        if (counter == numberOfLoops)
        {
            for (int i = 0; i < numberOfIterations; i++)
            {
                if (i == numberOfIterations - 1)
                {
                    Console.Write("{0}", loops[i]);
                    break;
                }
                Console.Write("{0}, ", loops[i]);
            }
            Console.WriteLine();
            return;
        }

        for (int i = 1; i <= numberOfIterations; i++)
        {
            loops[counter] = i;
            nestedLoops(counter + 1);
        }
    }
}