using System;
using System.IO;

class ReplaceSubstring
{
    static void Main()
    {
        //StreamReader readeLargeText = new StreamReader(@"..\..\largeText.txt");
        StreamReader readeLargeText = new StreamReader(@"..\..\smallerText.txt");
        StreamWriter writeChangedStartWithFinish = new StreamWriter(@"..\..\output.txt");

        using (readeLargeText)
        {
            using (writeChangedStartWithFinish)
            {
                writeChangedStartWithFinish.WriteLine(readeLargeText.ReadToEnd().ToString()
                    .Replace("start", "finish"));
            }
        }
    }
}

