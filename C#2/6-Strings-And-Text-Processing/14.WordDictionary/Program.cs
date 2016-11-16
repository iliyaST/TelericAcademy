using System;
using System.Collections;
using System.Collections.Generic;

class WordDictonary
{
    static void Main()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        dic.Add(".NET", "platform for applications from microsoft");
        dic.Add("CLR", "managed execution environment for .NET");
        dic.Add("NAMESPACE", "hierarchical organization of classes");

        string input = Console.ReadLine().ToUpper();

        while (input != "EXIT")
        {
            // bool ContainsKey(K) => check if there is an ordered pair with this key in the dictionary
            if (dic.ContainsKey(input))
            {
                Console.WriteLine(dic[input]);
            }
            else
            {
                Console.WriteLine("There is not such word in the dictionary.");
            }

            Console.WriteLine("Enter a word to see its translation or type EXIT to leave: ");
            input = Console.ReadLine().ToUpper();
        }
    }
}

