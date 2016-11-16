using System;
using System.Text;

class ExtractTextFrom
{
    static void Main()
    {
        string htmlFile = Console.ReadLine();
        string title = "";
        string body = "";

        int index = 0;
        int endIndex = 0;

        index = htmlFile.IndexOf("<title>", index);

        if (index >= 0)
        {
            index += 7;
            endIndex = htmlFile.IndexOf("</title>", index);
            title = htmlFile.Substring(index, endIndex - index);
        }

        index = endIndex + 7;

        index = htmlFile.IndexOf("<body>", index);
        endIndex = htmlFile.IndexOf("</body>", index + 7);

        if (index >= 0)
        {
            body = htmlFile.Substring(index + 6, endIndex - index - 6);
        }

        StringBuilder bodyOfHtml = new StringBuilder(body.Length);

        for (int i = 0; i < body.Length; i++)
        {
            if (body[i] == '<')
            {
                while (body[i] != '>')
                {
                    i++;
                }
                bodyOfHtml.Append((char)32);
                continue;
            }
            bodyOfHtml.Append(body[i]);
        }

        Console.WriteLine(title);
        Console.WriteLine(bodyOfHtml.ToString());
    }
}

