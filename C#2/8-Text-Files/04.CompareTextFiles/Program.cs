using System;
using System.IO;

class CompareTextFiles
{
    static void Main()
    {
        StreamReader readFirstText = new StreamReader(@"..\..\text1.txt");
        StreamReader readSecondText = new StreamReader(@"..\..\text2.txt");
        int sameLines = 0;
        int differentLines = 0;

        using (readFirstText)
        {
            using (readSecondText)
            {
                string currentLineFromFirstText = readFirstText.ReadLine();
                string currentLineFromSecondText = readSecondText.ReadLine();

                while (currentLineFromFirstText != null)
                {
                    if (currentLineFromFirstText == currentLineFromSecondText)
                    {
                        sameLines++;
                    }
                    else
                    {
                        differentLines++;
                    }

                    currentLineFromFirstText = readFirstText.ReadLine();
                    currentLineFromSecondText = readSecondText.ReadLine();
                }
            }
        }

        Console.WriteLine("The same lines are: {0} the different are: {1} .", sameLines, differentLines);
    }
}

