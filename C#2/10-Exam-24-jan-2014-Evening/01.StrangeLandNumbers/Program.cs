using System;
using System.Collections.Generic;
using System.Text;

class StrangeLandNumbers
{
    static void Main()
    {
        //the input that the user inserts
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder();
        //fill the words
        //List<string> list = new List<string>();
        //list.Add("f");
        //list.Add("bIN");
        //list.Add("oBJEC");
        //list.Add("mNTRAVL");
        //list.Add("lPVKNQ");
        //list.Add("pNWE");
        //list.Add("hT");

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == 'f')
            {
                sb.Append(0);
            }
            else if (input[i] == 'b')
            {
                sb.Append(1);
                i += 2;
            }
            else if (input[i] == 'o')
            {
                sb.Append(2);
                i += 4;
            }
            else if (input[i] == 'm')
            {
                sb.Append(3);
                i += 6;
            }
            else if (input[i] == 'l')
            {
                sb.Append(4);
                i += 3;
            }
            else if (input[i] == 'p')
            {
                sb.Append(5);
                i += 3;
            }
            else if (input[i] == 'h')
            {
                sb.Append(6);
                i += 1;
            }
        }
        //Console.WriteLine(sb);
        int pow = 0;
        long result = 0;

        for (int i = sb.Length - 1; i >= 0; i--)
        {
            long thePow = (long)Math.Pow(7, pow);
            int digit = int.Parse(sb[i].ToString());
            result += digit * thePow;
            pow++;
        }

        Console.WriteLine(result);
    }
    
}

