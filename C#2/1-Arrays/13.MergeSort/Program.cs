using System;

class MergeSort
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int[] sortedArray = mergeSort(array);

        Console.WriteLine(String.Join(" ", sortedArray));
    }

    static int[] mergeSort(int[] array)
    {

        if (array.Length == 1)
        {
            return array;
        }

        int median = array.Length / 2;
        int leftPart = median;
        int rightPart = array.Length - median;

        int[] arrayLeft = new int[leftPart];
        int[] arrayRight = new int[rightPart];

        for (int i = 0; i < leftPart; i++)
        {
            arrayLeft[i] = array[i];
        }

        for (int i = 0; i < rightPart; i++)
        {
            arrayRight[i] = array[i + median];
        }

        int[] sortedLeft = mergeSort(arrayLeft);
        int[] sortedRight = mergeSort(arrayRight);

        int[] sortedArray = new int[array.Length];
        int minLeft = 0;
        int minRight = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (minLeft >= arrayLeft.Length)
            {
                sortedArray[i] = sortedRight[minRight];
                minRight++;
            }
            else if (minRight >= arrayRight.Length)
            {
                sortedArray[i] = sortedLeft[minLeft];
                minLeft++;
            }
            else if (sortedLeft[minLeft] >= sortedRight[minRight])
            {
                sortedArray[i] = sortedRight[minRight];
                minRight++;
            }
            else if (sortedLeft[minLeft] <= sortedRight[minRight])
            {
                sortedArray[i] = sortedLeft[minLeft];
                minLeft++;
            }
        }
        return sortedArray;
    }
}
