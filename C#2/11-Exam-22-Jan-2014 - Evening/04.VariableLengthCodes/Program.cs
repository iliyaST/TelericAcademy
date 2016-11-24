using System;
using System.Collections.Generic;
using System.IO;

class NumberAsArray
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        Console.SetIn(sr);
        //enter sequence of integers
        string[] sequinceOfIntegers = Console.ReadLine().Split(' ');
        //number of Lines
        int numberOfLines = int.Parse(Console.ReadLine());
        List<string> listOfLines = new List<string>();
        List<string> listOfNumbers = new List<string>();
        //add lines to the list
        for (int i = 0; i < numberOfLines; i++)
        {
            string temp = Console.ReadLine();

            string result = "";
            string result1 = "";

            for (int q = temp.Length - 1; q >= 0; q--)
            {
                if (Char.IsDigit(temp[q]))
                {
                    result = temp[q] + result;
                }
                else
                {
                    result1 += temp[q];
                }
            }

            listOfNumbers.Add(result);
            listOfLines.Add(result1);
        }

        //convert to binary the 2 numbers
        string resultedBinaryNumber = "";

        for (int i = 0; i < sequinceOfIntegers.Length; i++)
        {
            resultedBinaryNumber += Convert.ToString(int.Parse(sequinceOfIntegers[i]), 2).PadLeft(8,'0');
        }     

        string decodedText = Decode(resultedBinaryNumber, listOfLines, listOfNumbers);

        Console.WriteLine(decodedText);
    }

    static string Decode(string text, List<string> listLines, List<string> listNumbers)
    {
        string decodedText = "";
        int counter = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '1')
            {
                counter = 0;
                int b = i;

                while (text[b] == '1')
                {
                    counter++;
                    b++;
                }

                for (int j = 0; j < listNumbers.Count; j++)
                {
                    if (int.Parse(listNumbers[j]) == counter)
                    {
                        decodedText += listLines[j];
                        i += counter - 1;
                        break;
                    }
                }
            }
        }
        return decodedText;
    }
}
