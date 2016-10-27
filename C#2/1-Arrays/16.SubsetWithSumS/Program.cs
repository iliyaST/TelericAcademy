using System;

class SubsetWithSumS
{
    static int N;
    static int[] array;
    static int targetS;
    static int[] subSet;
    static int currentSum;
    static int counter;

    static void Main()
    {
        counter = 0;
        //insert array lendth
        Console.WriteLine("Enter Arrays Lenght please!");
        N = int.Parse(Console.ReadLine());
        int currentSum = 0;
        subSet = new int[N];
        //enter S
        Console.WriteLine("Enter SubSet Sum please!");
        targetS = int.Parse(Console.ReadLine());
        array = new int[N];
        //fill array
        Console.WriteLine("Enter the elements of the Array please!");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        //call method
        findSubset(subSet, 0);
        //check counter
        if (counter == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(counter);
        }
    }

    private static void findSubset(int[] subSet, int index)
    {
        //bottom of recursion 
        if (index == array.Length)
        {
            for (int i = 0; i < subSet.Length; i++)
            {
                Console.Write(subSet[i] + " ");
                currentSum += subSet[i];
            }

            Console.WriteLine();
            Console.WriteLine(currentSum);

            if (currentSum == targetS)
            {
                counter++;
            }
            currentSum = 0;

            return;
        }
        //call recusion with number
        subSet[index] = array[index];
        findSubset(subSet, index + 1);
        //call without number (in our case 0)
        subSet[index] = 0;
        findSubset(subSet, index + 1);

    }
}



