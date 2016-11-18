using System;
using System.IO;
using System.Text;

class ExtractTextFromXML
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\input.txt");
        string input = string.Empty;
        StringBuilder output = new StringBuilder();

        using (readFile)
        {
            input = readFile.ReadToEnd();
        }

        bool isTag = false;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '<')
            {
                isTag = true;
            }

            if (!isTag)
            {
                output.Append(input[i]);
            }

            if (input[i] == '>')
            {
                isTag = false;
            }
        }

        StreamWriter writeFile = new StreamWriter(@"..\..\output.txt");

        using (writeFile)
        {
            writeFile.WriteLine(output.ToString());
        }

    }
}