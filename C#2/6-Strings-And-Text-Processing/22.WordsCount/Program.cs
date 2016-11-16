using System;
using System.Collections.Generic;
using System.Text;

class WordsCount
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        Dictionary<string, int> dic = new Dictionary<string, int>();

        //find all punctoational signs
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsPunctuation(text[i]))
            {
                sb.Append(text[i]);
            }
        }
        //add space char symbol for space in Asci Table is 32 
        sb.Append((char)32);

        string punctoation = sb.ToString();
        //find all words
        string[] words = text.Split(punctoation.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (dic.ContainsKey(word))
            {
                dic[word]++;
            }
            else
            {
                dic.Add(word, 1);
            }
        }

        foreach (var word in dic)
        {
            Console.WriteLine("word {0} - {1} times", word.Key, word.Value);
        }

    }
}

