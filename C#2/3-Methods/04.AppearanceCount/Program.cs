using System;

class AppearanceCount
{
    static int AppearanceCounter(int[] array, int length, int givenNumber)
    {
        int counter = 0;

        for (int i = 0; i < length; i++)
        {
            if (array[i] == givenNumber)
            {
                counter++;
            }
        }

        return counter;
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        string[] inputArray = Console.ReadLine().Split(new char[] { ' ' });
        int X = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(inputArray[i]);
        }

        int appearanceCount = AppearanceCounter(array, N, X);

        Console.WriteLine(appearanceCount);
    }
}

