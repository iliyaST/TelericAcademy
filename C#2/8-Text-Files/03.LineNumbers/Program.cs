using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        StreamReader readTheText = new StreamReader(@"..\..\changelog.txt");
        StreamWriter changedTextWriter = new StreamWriter(@"..\..\result.txt");
        string textFromFile = String.Empty;
        string changedText = String.Empty;

        using (readTheText)
        {
            using (changedTextWriter)
            {
                string currentLine = readTheText.ReadLine();
                int counter = 1;

                while (currentLine != null)
                {
                    changedTextWriter.WriteLine(string.Format("{0}.{1}", counter, currentLine));
                    counter++;
                    currentLine = readTheText.ReadLine();
                }
            }
        }
    }
}

