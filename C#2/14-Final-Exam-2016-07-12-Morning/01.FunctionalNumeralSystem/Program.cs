using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class FunctionalNumeralSystem
{
    static List<string> fillTheList(List<string> someList)
    {
        List<string> list = new List<string>();

        list.Add("ocaml");
        list.Add("haskell");
        list.Add("scala");
        list.Add("f#");
        list.Add("lisp");
        list.Add("rust");
        list.Add("ml");
        list.Add("clojure");
        list.Add("erlang");
        list.Add("standardml");
        list.Add("racket");
        list.Add("elm");
        list.Add("mercury");
        list.Add("commonlisp");
        list.Add("scheme");
        list.Add("curry");

        return list;
    }

    static string[] findWords(string text)
    {
        string[] words = text.Split(' ');
        string[] newWords = new string[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            string currentWord = words[i];
            int j = 0;

            while (currentWord[j] != ',')
            {
                newWords[i] += currentWord[j];
                j++;
                if (j >= currentWord.Length)
                {
                    break;
                }
            }

        }

        return newWords;
    }

    static void Main()
    {
        //enter input
        string input = Console.ReadLine();

        string[] words = findWords(input);

        //string firstNumer = words[0];//first
        //string secondNumber = words[1];//second
        //string thirdNumber = words[2];//third

        //create numerSystem
        List<string> someSystem = new List<string>();
        someSystem = fillTheList(someSystem);

        BigInteger result = 1;

        foreach (var word in words)
        {
            string tempNumber = String.Empty;
            string convertedWord = String.Empty;
            BigInteger temp = 0;

            for (int j = 0; j < word.Length; j++)
            {
                tempNumber += word[j];

                for (int i = 0; i < someSystem.Count; i++)
                {
                    if (someSystem[i] == tempNumber)
                    {
                        temp = temp * 16 + i;
                        tempNumber = "";
                        break;
                    }
                }
            }

            result *= temp;
        }

        Console.WriteLine(result);
    }
}

