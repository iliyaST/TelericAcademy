using System;
using System.Collections.Generic;
using System.IO;

class PrefixTest
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\input.txt");
        List<string> words = new List<string>();
        StreamWriter writer = new StreamWriter(@"..\..\output.txt");

        using (reader)
        {
            string currentLine = reader.ReadLine();

            while (currentLine != null)
            {
                string[] input = currentLine.Split(new char[] { ' ' });

                for (int i = 0; i < input.Length; i++)
                {
                    words.Add(input[i]);
                }

                currentLine = reader.ReadLine();
            }
        }

        using (writer)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length > 4)
                {
                    if (words[i].Substring(0, 4) == "test")
                    {
                        writer.WriteLine(words[i]);
                    }
                }
            }
        }


    }
}

