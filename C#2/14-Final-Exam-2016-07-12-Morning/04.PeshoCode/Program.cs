using System;
using System.Collections.Generic;
using System.Text;

class PeshoCode
{
    static void Main()
    {
        string word = Console.ReadLine();
        word = word.ToUpper();
        int lines = int.Parse(Console.ReadLine());
        string resultSubstring = String.Empty;
        StringBuilder sb = new StringBuilder();
        ulong result = 0;

        for (int i = 0; i < lines; i++)
        {
            sb.Append(Console.ReadLine() + " ");
        }

        string theText = sb.ToString();
        theText = theText.ToUpper();

        sb.Clear();

        int index = 0;

        index = theText.IndexOf(word, index);

        int q = index;

        while (true)
        {
            if (theText[q] == '.' || theText[q] == '?' || q == 0)
            {
                break;
            }
            q--;
        }

        if (index < 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            //find the index of the first ? and .
            int otherIndexQestion = index + word.Length;
            int otherIndexPoint = otherIndexQestion;

            otherIndexQestion = theText.IndexOf("?", otherIndexQestion);
            otherIndexPoint = theText.IndexOf(".", otherIndexPoint);

            if ((otherIndexPoint < 0 && otherIndexQestion > 0) || ((otherIndexPoint > otherIndexQestion) && otherIndexQestion > 0))
            {
                int j = index + word.Length;
                while (theText[j] != '?')
                {
                    if (theText[j] != ' ')
                    {
                        //sb.Append(theText[j]);
                        result += theText[j];
                    }
                    j++;
                }
            }
            else if ((otherIndexPoint > 0 && otherIndexQestion < 0) || ((otherIndexPoint < otherIndexQestion) && otherIndexPoint > 0))
            {
                int j = 0;

                if (q == 0)
                {
                    j = q;
                }
                else
                {
                    j = q + 1;
                }

                while (j < index)
                {
                    if (theText[j] != ' ')
                    {
                        //sb.Append(theText[j]);
                        result += theText[j];
                    }
                    j++;
                }
            }
        }
        Console.WriteLine(result);
    }
}

