using System;
using System.Text;

class ReplaceTags
{
    static void Main()
    {
        string text = Console.ReadLine();

        string[] splitedText = text.Split(new string[] { "<a href", "</a>" },
            StringSplitOptions.None);

        StringBuilder replacedText = new StringBuilder();

        foreach (var part in splitedText)
        {
            int index = part.IndexOf("=\"");

            if (index < 0)
            {
                replacedText.Append(part);
            }
            else
            {
                int endIndex = part.IndexOf("\">");
                replacedText.Append("[");
                replacedText.Append(part.Substring(endIndex + 2, part.Length - 2 - endIndex));
                replacedText.Append("](");
                replacedText.Append(part.Substring(index + 2, endIndex - index - 2));
                replacedText.Append(")");
            }
        }

        if (replacedText.Length != 0)
        {
            Console.WriteLine(replacedText.ToString());
        }
        else
        {
            Console.WriteLine(text);
        }
    }
}

