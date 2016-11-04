using System;
using System.Collections.Generic;

class NumberAsArray
{
    // find the len of the sum Array
    static int maxLength(int len1, int len2)
    {
        int len = 0;

        if (len1 > len2)
        {
            len = len1;
        }
        else
        {
            len = len2;
        }

        return len;
    }
    //find the len of the smaller Array
    static int minLength(int len1, int len2)
    {
        int minLen1 = 0;

        if (len1 > len2)
        {
            minLen1 = len2;
        }
        else
        {
            minLen1 = len1;
        }

        return minLen1;
    }

    static string TwoNumbersAsArrays(List<int> firstArray, List<int> secondArray, int len1, int len2)
    {
        //find the bigger size
        int maxLen = maxLength(len1, len2);
        //find the smaller size
        int minLen = minLength(len1, len2);

        //create the third array using bigger size(figure it)
        List<int> sumArray = new List<int>();
        int bonus = 0;

        for (int i = 0; i < maxLen; i++)
        {
            if (i >= minLen)
            {
                if (len1 > len2)
                {
                    secondArray.Add(0);
                }
                else
                {
                    firstArray.Add(0);
                }
                minLen++;
            }

            if (firstArray[i] + secondArray[i] + bonus > 9)
            {
                sumArray.Add((firstArray[i] + secondArray[i] + bonus) % 10);
                bonus = 1;
                continue;
            }
            if (firstArray[i] + secondArray[i] > 9)
            {
                sumArray.Add((firstArray[i] + secondArray[i] + bonus) % 10);
                bonus = 1;
                continue;
            }
            sumArray.Add(firstArray[i] + secondArray[i] + bonus);
            bonus = 0;
        }

        //return the resulted array
        string result = "";

        for (int i = 0; i < sumArray.Count; i++)
        {
            if (i == sumArray.Count - 1)
            {
                result += sumArray[i].ToString();
                continue;
            }
            result += sumArray[i].ToString() + " ";
        }

        return result;
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' });

        int firstSize = int.Parse(input[0]);
        int secondSize = int.Parse(input[1]);

        List<int> firstArray1 = new List<int>();
        List<int> secondArray2 = new List<int>();

        string[] inputFirstArray = Console.ReadLine().Split(new char[] { ' ' });
        string[] inputSecondArray = Console.ReadLine().Split(new char[] { ' ' });

        for (int i = 0; i < firstSize; i++)
        {
            firstArray1.Add(int.Parse(inputFirstArray[i]));
        }
        for (int i = 0; i < secondSize; i++)
        {
            secondArray2.Add(int.Parse(inputSecondArray[i]));
        }

        string result = TwoNumbersAsArrays(firstArray1, secondArray2, firstSize, secondSize);

        Console.WriteLine(result);
    }
}