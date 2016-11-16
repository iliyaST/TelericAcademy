using System;

class SubStringInText
{
    static int HowManyTimesIsContained(string subString, string text)
    {
        int index = 0;
        int subStringLen = subString.Length;
        int subCounter = 0;

        while (index < text.Length)
        {
            index = text.IndexOf(subString, index);

            if (index < 0 || index + subStringLen > text.Length)
            {
                break;
            }

            string tempSub = text.Substring(index, subStringLen);

            if (tempSub == subString)
            {
                subCounter++;
            }

            index += subStringLen;
        }
        return subCounter;
    }

    static void Main()
    {
        string subString = Console.ReadLine().ToLower();
        string theString = Console.ReadLine().ToLower();

        int result = HowManyTimesIsContained(subString, theString);

        Console.WriteLine(result);
    }
}

