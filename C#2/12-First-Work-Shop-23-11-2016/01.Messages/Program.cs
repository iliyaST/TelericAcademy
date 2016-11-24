using System;
using System.Collections.Generic;
using System.Numerics;

class Messages
{
    static void Main()
    {
        List<string> words = new List<string>();
        words.Add("cad");
        words.Add("xoz");
        words.Add("nop");
        words.Add("cyk");
        words.Add("min");
        words.Add("mar");
        words.Add("kon");
        words.Add("iva");
        words.Add("ogi");
        words.Add("yan");

        string firstNumberInGTG = Console.ReadLine();
        string operation = Console.ReadLine();
        string secondNumberInGTG = Console.ReadLine();

        BigInteger firstNumberConvertedToDecimal = BigInteger.Parse(ConvertToDecimal(firstNumberInGTG, words));
        BigInteger secondNumberConvertedToDecimal = BigInteger.Parse(ConvertToDecimal(secondNumberInGTG, words));
        string result = "";

        if (operation == "-")
        {
            result = (firstNumberConvertedToDecimal - secondNumberConvertedToDecimal).ToString();
        }
        else
        {
            result = (firstNumberConvertedToDecimal + secondNumberConvertedToDecimal).ToString();
        }

        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(words[int.Parse(result[i].ToString())]);
        }

        Console.WriteLine();
    }

    static string ConvertToDecimal(string text, List<string> words)
    {
        string temp = "";
        int counter = 0;
        string result = "";

        for (int i = 0; i <= text.Length; i++)
        {
            if (counter == 3)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (words[j] == temp)
                    {
                        result += j;
                        break;
                    }
                }
                temp = "";
                counter = 0;
            }
            if (i == text.Length)
            {
                break;
            }
            temp += text[i];
            counter++;
        }

        return result;
    }
}

