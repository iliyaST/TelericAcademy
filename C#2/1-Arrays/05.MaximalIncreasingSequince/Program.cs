using System;
using System.Collections.Generic;

class MaximalIncreasingSequince
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] Array = new int[N];
        List<int> maxArray = new List<int>();
        List<int> subArray = new List<int>();
        int max = 0;
        bool isEnd = false;

        for (int i = 0; i < N; i++)
        {
            Array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            if (isEnd == true)
            {
                break;
            }
            int iCounter = i;
            int counter = 0;
            if (iCounter >= N - 1)
            {
                counter = 1;
                isEnd = true;
                if (Array[iCounter - 1] < Array[iCounter])
                {
                    subArray.Add(Array[iCounter]);
                    counter++;
                }
                if (max < counter)
                {
                    maxArray.Clear();
                    foreach (var number in subArray)
                    {
                        maxArray.Add(number);
                    }
                    subArray.Clear();
                    max = counter;
                }
                break;
            }
            // 1 2 3 2 1 0 2 3 4 5

            while (true)
            {
                if (Array[iCounter] < Array[iCounter + 1])
                {
                    subArray.Add(Array[iCounter]);
                    counter++;
                }
                else
                {
                    counter++;

                    if (counter <= max)
                    {
                        subArray.Clear();
                        break;
                    }

                    subArray.Add(Array[iCounter]);                    

                    if (max < counter)
                    {
                        maxArray.Clear();
                        foreach (var number in subArray)
                        {
                            maxArray.Add(number);
                        }
                        subArray.Clear();
                        max = counter;
                    }
                    i += counter - 1;
                    break;
                }
                iCounter++;
                // 1 2 3 2 1 0 2 3 4 5
                if (iCounter >= N - 1)
                {
                    isEnd = true;
                    if (Array[iCounter - 1] < Array[iCounter])
                    {
                        subArray.Add(Array[iCounter]);
                        counter++;
                    }
                    if (max < counter)
                    {
                        maxArray.Clear();
                        foreach (var number in subArray)
                        {
                            maxArray.Add(number);
                        }
                        subArray.Clear();
                        max = counter;
                    }
                    break;
                }
            }
        }

        for (int i = 0; i < max; i++)
        {         
            if (i == max - 1)
            {
                Console.Write(maxArray[max-1]);
                break;
            }
            Console.Write(maxArray[i] + ", ");
        }
        Console.WriteLine();
    }
}

