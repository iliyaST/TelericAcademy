using System;
using System.Text;

class ReverseString
{
    static string Reverse(string text)
    {
        var randomText = new StringBuilder();

        for (int i = text.Length - 1; i >= 0; i--)
        {
            randomText.Append(text[i]);
        }

        return randomText.ToString();
    }


    static void Main()
    {
        string text = Console.ReadLine();

        text = Reverse(text);

        Console.WriteLine(text);
    }
}

