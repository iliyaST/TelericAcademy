using System;
using System.Linq;
using System.Text;

class ReverseSentence
{
    static void Main()
    {
        string text = Console.ReadLine();

        char lastSign = text[text.Length - 1];

        string[] words = text.Substring(0, text.Length - 1)
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = words.Length - 1; i >= 0; i--)
        {
            if (words[i].Contains(","))
            {
                words[i] = words[i].Replace(',', ' ');
                words[i + 1] = ", " + words[i + 1];
            }
        }

        Array.Reverse(words);

        Console.Write(words[0]);
        for (int i = 1; i < words.Length; i++)
        {
            if (words[i].Contains(","))
            {
                Console.Write(words[i]);
            }
            else
            {
                Console.Write(" " + words[i]);
            }
        }
        Console.WriteLine(lastSign);
    }
}

