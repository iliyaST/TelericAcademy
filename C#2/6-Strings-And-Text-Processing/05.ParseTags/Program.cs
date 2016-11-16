using System;
using System.Text;

class ParseTags
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder newText = new StringBuilder();
        bool isOpened = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '<')
            {
                while (text[i] != '>')
                {
                    i++;
                }

                i++;

                while (text[i] != '<')
                {
                    newText.Append(text[i].ToString().ToUpper());
                    i++;
                }
                while (text[i] != '>')
                {
                    i++;
                }
                continue;
            }

            newText.Append(text[i]);
        }
        Console.WriteLine(newText);
    }
}

