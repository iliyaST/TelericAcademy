using System;

class MergingNumbers
{
    static void Merging(int[] array)
    {
        int currentProduct = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length - 2)
            {
                currentProduct = array[i] % 10 * 10 + array[i + 1] / 10 % 10;
                Console.Write(currentProduct + " ");
                break;
            }
            currentProduct = array[i] % 10 * 10 + array[i+1] / 10 % 10;
            Console.Write(currentProduct + " ");           
        }
        Console.WriteLine();
    }



    static void Sum(int[] array)
    {
        int currentSum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length - 2)
            {
                currentSum += array[i] + array[i + 1];
                Console.Write(currentSum + " ");
                break;
            }
            currentSum += array[i] + array[i + 1];
            Console.Write(currentSum + " ");
            currentSum = 0;
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Merging(array);
        Sum(array);

    }
}

