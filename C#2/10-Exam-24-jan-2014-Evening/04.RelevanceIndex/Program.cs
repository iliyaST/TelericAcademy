using System;
using System.Collections.Generic;

class RelavanceIndex
{
    static void Main()
    {
        string word = Console.ReadLine();
        int numberOfParagraphs = int.Parse(Console.ReadLine());
        string[][] arrayOfParagraphs = new string[numberOfParagraphs][];
        List<int> listOfOccurrances = new List<int>();
        for (int i = 0; i < numberOfParagraphs; i++)
        {
            int currentOccurranceOfWord = 0;
            string[] currentParagraph = Console.ReadLine().Split(new char[] { ',', '.', '(', ')', ';', '-', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            arrayOfParagraphs[i] = new string[currentParagraph.Length + 1];
            for (int j = 0; j < currentParagraph.Length; j++)
            {
                if (currentParagraph[j].ToLower() == word.ToLower())
                {
                    currentOccurranceOfWord++;
                    arrayOfParagraphs[i][j] = currentParagraph[j].ToUpper();
                    continue;
                }
                arrayOfParagraphs[i][j] = currentParagraph[j];
            }
            arrayOfParagraphs[i][currentParagraph.Length] = currentOccurranceOfWord.ToString();
            listOfOccurrances.Add(currentOccurranceOfWord);
        }

        for (int i = 0; i < numberOfParagraphs; i++)
        {
            for (int j = 0; j < arrayOfParagraphs[i][j].Length; j++)
            {
                int max = int.MinValue;
                for (int z = 0; z < listOfOccurrances.Count; z++)
                {
                    if (max < listOfOccurrances[z])
                    {
                        max = listOfOccurrances[z];
                    }
                }
                for (int q = 0; q < listOfOccurrances.Count; q++)
                {
                    //get last index
                    int g = arrayOfParagraphs[q].Length - 1;
                    if (int.Parse(arrayOfParagraphs[q][g]) == max)
                    {
                        listOfOccurrances[q] = int.MinValue;
                        for (int t = 0; t < arrayOfParagraphs[q].Length-1; t++)
                        {
                            Console.Write(arrayOfParagraphs[q][t]+" ");
                        }
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }

    }
}

