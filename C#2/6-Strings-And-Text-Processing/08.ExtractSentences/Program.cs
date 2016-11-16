using System;
using System.Linq;

class ExtractSentences
{
    private static char[] GetNonLetterSymbols(string input)
    {
        char[] symbols = input
            .Where(ch => !char.IsLetter(ch))
            .Distinct()
            .ToArray();

        return symbols;
    }
    static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        char[] separators = GetNonLetterSymbols(text);

        foreach (var sentence in sentences)
        {
            string[] words = sentence.Split(separators,
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var singleWord in words)
            {
                if (singleWord == word)
                {
                    Console.Write(sentence.Trim() + ". ");
                    break;
                }
            }

        }
    }
}

