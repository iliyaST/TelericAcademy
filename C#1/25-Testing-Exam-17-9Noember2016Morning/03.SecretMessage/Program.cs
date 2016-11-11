using System;

class SecretMessage
{
    static string encodingTheLine(int startIndex, int endIndex, string inputToDecode,int counter)
    {
        string encoding = "";

        if (startIndex < 0)
        {
            startIndex = inputToDecode.Length - (-startIndex);
        }
        if (endIndex < 0)
        {
            endIndex = inputToDecode.Length - (-endIndex);
        }       

        if (counter % 2 == 0)
        {
            for (int i = startIndex; i <= endIndex; i += 4)
            {
                encoding += inputToDecode[i];
            }
        }
        else
        {
            for (int i = startIndex; i <= endIndex; i += 3)
            {
                encoding += inputToDecode[i];
            }
        }

        return encoding;
    }

    static void Main()
    {
        string endcoding = "";
        int counter = 0;

        while (true)
        {
            string startIndex = Console.ReadLine();
            int start;

            if (!int.TryParse(startIndex, out start))
            {
                break;
            }

            int endIndex = int.Parse(Console.ReadLine());

            string tempLine = Console.ReadLine();

            counter++;

            endcoding += encodingTheLine(start, endIndex, tempLine,counter);
        }

        Console.WriteLine(endcoding);
    }
}

