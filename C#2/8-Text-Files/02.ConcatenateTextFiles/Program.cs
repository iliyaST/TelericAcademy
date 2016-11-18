using System;
using System.IO;

class ConcatenateTextFiles
{
    static void Main()
    {
        var readFirstFile = new StreamReader(@"..\..\New Playlist.txt");
        var readSecondFile = new StreamReader(@"..\..\PlayList3.txt");
        var writeTheResult = new StreamWriter(@"..\..\resulted.txt");
        string textFromFirstFile = String.Empty;
        string textFromSecondFile = String.Empty;

        using (readFirstFile)
        {
            textFromFirstFile = readFirstFile.ReadToEnd();
        }
        using (readSecondFile)
        {
            textFromSecondFile = readSecondFile.ReadToEnd();
        }

        string concatenatedText = textFromFirstFile + textFromSecondFile;

        using (writeTheResult)
        {
            writeTheResult.WriteLine(concatenatedText);
        }

    }
}

