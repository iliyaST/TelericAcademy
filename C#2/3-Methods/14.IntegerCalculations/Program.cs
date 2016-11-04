using System;
using System.Numerics;

class IntegerCalculations
{
    static void min(int[] array)
    {
        int min = int.MaxValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }

        Console.WriteLine(min);
    }

    static void max(int[] array)
    {
        int max = int.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        Console.WriteLine(max);
    }

    static void Average(int[] array)
    {
        double average = 0;

        for (int i = 0; i < array.Length; i++)
        {
            average += array[i];
        }

        average /= array.Length;

        Console.WriteLine("{0:F2}", average);
    }

    static void Sum(int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        Console.WriteLine(sum);
    }

    static void Product(int[] array)
    {
        BigInteger product = 1;

        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
        }

        Console.WriteLine(product);
    }

    static void Main()
    {
        int N = 5;
        int[] array = new int[5];

        string[] arrayOfIntegers = Console.ReadLine().Split(new char[] { ' ' });

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(arrayOfIntegers[i]);
        }

        min(array);
        max(array);
        Average(array);
        Sum(array);
        Product(array);
    }
}

