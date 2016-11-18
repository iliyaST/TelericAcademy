using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\PlayList3.txt");

        using (reader)
        {
            string currentLine = reader.ReadLine();
            int counter = 0;
            while (currentLine != null)
            {
                if (counter % 2 != 0)
                {
                    Console.WriteLine(currentLine);
                }
                counter++;
                currentLine = reader.ReadLine();
            }
        }
    }
}

