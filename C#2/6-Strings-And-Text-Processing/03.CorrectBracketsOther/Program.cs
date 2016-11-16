using System;

class CorrectBracketsOther
{
    static bool CheckBrackets(string text)
    {
        int index = 0;
        int openBrackets = 0;
        int closedBrackets = 0;

        while (index < text.Length)
        {
            index = text.IndexOfAny(new char[] { '(', ')' },index);

            if (index < 0)
            {
                break;
            }
            else if (text[index] == '(')
            {
                openBrackets++;
            }
            else
            {
                closedBrackets++;
            }

            index++;
        }

        if (openBrackets == closedBrackets)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        string text = Console.ReadLine();

        bool result = CheckBrackets(text);

        if (result)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }
}

