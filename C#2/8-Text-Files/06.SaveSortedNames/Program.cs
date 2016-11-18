using System;
using System.Collections.Generic;
using System.IO;

class SaveSortedNames
{
    static void Main()
    {
        StreamReader readerInput = new StreamReader(@"..\..\input.txt");
        StreamWriter writerOutput = new StreamWriter(@"..\..\output.txt");
        List<string> names = new List<string>();

        using (readerInput)
        {
            string currentLine = readerInput.ReadLine();

            while (currentLine != null)
            {
                names.Add(currentLine);
                currentLine = readerInput.ReadLine();
            }
        }

        for (int i = 0; i < names.Count - 1; i++)
        {
            for (int j = i + 1; j < names.Count; j++)
            {
                if (names[i].CompareTo(names[j]) > 0)
                {
                    string temp = names[i];
                    names[i] = names[j];
                    names[j] = temp;
                }
            }
        }

        using (writerOutput)
        {
            for (int i = 0; i < names.Count; i++)
            {
                writerOutput.WriteLine(names[i]);
            }
        }
    }
}

