using System;

class MaximalSum
{
    static void Main()
    {
        int numberOfEl = int.Parse(Console.ReadLine());
        int[] array = new int[numberOfEl];
        int counter = numberOfEl;
        int currentSum = 0;
        int maxSum = int.MinValue;

        //fill the array
        for (int i = 0; i < numberOfEl; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        //do all possible variatons of subArrays from N el. from N -1 from N -2 and so..... till we get to 0
        while (counter != 0)
        {
            currentSum = 0;
            //we always save the full array in this for(i to numberOfEl)
            for (int i = 0; i < numberOfEl; i++)
            {
                // then we start with the subArrays: first we have with N el.... i + counter = 10
                for (int j = i; j < i + counter; j++)
                {
                    currentSum += array[j];
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    currentSum = 0;
                }
                //so every time we start from the begining of the subArray j=i we get to the end of the subArray (counter) 
                //and if we get to the end of the generalArray (i to N) we break; i + counter =?
                if (i + counter == numberOfEl)
                {
                    break;
                }
                currentSum = 0;
            }
            counter--;
        }
        Console.WriteLine(maxSum);
    }
}


