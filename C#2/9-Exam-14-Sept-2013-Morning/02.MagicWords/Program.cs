using System;
using System.Collections.Generic;

class MagicWords
{
    static void Main()
    {
        int numberOfWords = int.Parse(Console.ReadLine());
        var words = new List<string>();

        for (int i = 0; i < numberOfWords; i++)
        {
            words.Add(Console.ReadLine());           
        }

        for (int i = 0; i < numberOfWords; i++)
        {
            int newIndex = words[i].Length % (numberOfWords + 1);
            words.Insert(newIndex, words[i]);

            if (newIndex < i)
            {
                words.RemoveAt(i + 1);
            }
            else
            {
                words.RemoveAt(i);
            }
        }

        int index = 0;
        string temp = "randomValue";

        while (temp!="")
        {
            temp = "";
            for (int i = 0; i < words.Count; i++)
            {
                var word = words[i];
                
                if (index < word.Length)
                {
                    temp += word[index];
                    continue;
                }
            }
            Console.Write(temp);
            index++;
        }
        Console.WriteLine();

    }
}

