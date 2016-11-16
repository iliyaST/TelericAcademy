using System;
using System.Linq;
using System.Text;

class ForbiddenWords
{
    static void Main()
    {
        string[] forbiddenWords = Console.ReadLine().Split(new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();

        StringBuilder newText = new StringBuilder();

        newText.Append(text);

        foreach (var word in forbiddenWords)
        {
            newText.Replace(word, new string('*', word.Length));
        }

        Console.WriteLine(newText);
    }
}

