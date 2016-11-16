/*  20. Palindromes
    Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.
 */

using System;
using System.Text;

class Palindromes
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsPunctuation(text[i]))
            {
                sb.Append(text[i]);
            }
        }

        sb.Append((char)32);

        string punctoation = sb.ToString();

        string[] words = text.Split(punctoation.ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            bool isPolindromn = true;

            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i] && word[i] != (char)(word[word.Length - 1 - i] - 32))
                {
                    isPolindromn = false;
                    break;
                }
            }
            if (isPolindromn && word.Length > 1)
            {
                Console.WriteLine(word + " ");
            }
        }


    }
}