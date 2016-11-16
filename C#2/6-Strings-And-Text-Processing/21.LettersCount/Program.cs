using System;
using System.Collections;
using System.Collections.Generic;

class LettersCount
{
    static void Main()
    {
        string text = Console.ReadLine();

        Dictionary<char, int> dic = new Dictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                if (dic.ContainsKey(text[i]))
                {
                    dic[text[i]]++;
                }
                else
                {
                    dic.Add(text[i], 1);
                }
            }
        }

        foreach(var pair in dic)
        {
            Console.WriteLine("char: {0} - {1} times.",pair.Key,pair.Value);
        }
    }
}

