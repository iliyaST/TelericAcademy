using System;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\input.txt");       
        StringBuilder result = new StringBuilder();

        using (reader)
        {
            string currentLine = reader.ReadLine();
            int counter = 1;

            while (currentLine != null)
            {
                if (counter % 2 != 0)
                {
                    result.Append(currentLine);
                    result.Append("\r\n");
                }
                currentLine = reader.ReadLine();
                counter++;
            }
        }

        StreamWriter writer = new StreamWriter(@"..\..\input.txt");

        using (writer)
        {
            writer.WriteLine(result.ToString());
        }
    }
}

