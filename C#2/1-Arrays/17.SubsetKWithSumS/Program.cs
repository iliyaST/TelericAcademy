using System;

class SubsetKWithSumS
{
    static int[] array;
    static int[] subArray;
    static int N;
    static int K;
    static int S;
    static int currentSum;
    static int counter;

    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        K = int.Parse(Console.ReadLine());
        S = int.Parse(Console.ReadLine());

        array = new int[N];
        subArray = new int[K];
        currentSum = 0;
        counter = 0;

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        SubsetKWithS(subArray, 0, 0);
        Console.WriteLine();
        Console.WriteLine(counter);
    }

    private static void SubsetKWithS(int[] subArray, int index, int setIndex)
    {
        if (index == K)
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(subArray[i] + " ");
                currentSum += subArray[i];
            }           
            if (currentSum == S)
            {
                Console.Write("Yes{0}", S);
                counter++;
            }
            Console.WriteLine();
            currentSum = 0;

            return;
        }

        for (int i = setIndex; i < array.Length; i++)
        {
            subArray[index] = array[i];
            SubsetKWithS(subArray, index + 1, i+1);
        }
    }
}

