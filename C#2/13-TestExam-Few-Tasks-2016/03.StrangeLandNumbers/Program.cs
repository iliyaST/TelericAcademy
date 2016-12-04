using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class StrangeLandNumbers
{
    //1256
    static BigInteger ConvertToDecFinal(string text)
    {
        BigInteger result = 0;
        int pow = text.Length - 1;

        for (int i = 0; i < text.Length; i++)
        {
            int digit = int.Parse(text[i].ToString());
            result += digit * BigInteger.Pow(7, pow);
            pow--;
        }

        return result;
    }

    static void Main()
    {
        //bINoBJECpNWEhT
        string input = Console.ReadLine();

        List<string> someSystem = new List<string>();
        //fill the list
        someSystem.Add("f");
        someSystem.Add("bIN");
        someSystem.Add("oBJEC");
        someSystem.Add("mNTRAVL");
        someSystem.Add("lPVKNQ");
        someSystem.Add("pNWE");
        someSystem.Add("hT");

        string converted = ConvertToDecimal(input, someSystem);

        BigInteger result = ConvertToDecFinal(converted);

        Console.WriteLine(result);
    }

    private static string ConvertToDecimal(string input, List<string> list)
    {
        StringBuilder sb = new StringBuilder();
        //bINoBJECpNWEhTf

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (Char.IsLower(currentChar))
            {
                string word = String.Empty;

                word += currentChar;
                int index = i + 1;

                if (index >= input.Length)
                {
                    sb.Append("0");
                    break;
                }
                //f

                //while Char is Upper 
                while (Char.IsUpper(input[index]))
                {
                    currentChar = input[index];
                    word += currentChar;
                    index++;
                    if (index == input.Length)
                    {
                        break;
                    }
                }
                //bIN

                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] == word)
                    {
                        sb.Append(j); //1
                        i += word.Length - 1;
                        break;
                    }
                }
            }
        }

        return sb.ToString();
    }
}

