using System;

class OrderWords
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (words[i].CompareTo(words[j]) > 0)
                {
                    string temp = words[j];
                    words[j] = words[i];
                    words[i] = temp;
                }
            }
        }

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}

