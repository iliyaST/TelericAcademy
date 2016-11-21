using System;
using System.Collections.Generic;
using System.Text;

class MultiverseCommunication
{


    static int allWords(string word,List<string> list)
    {
       
        int index = 0;       

        for (int i = 0; i < list.Count; i++)
        {
            if (word == list[i])
            {
                index = i;
                break;
            }
        }

        return index;
    }

    static long toDecimal(string text,List<string> list)
    {
        long result = 0;
        int counter = 0;
        StringBuilder word = new StringBuilder(3);
        int powCounter = 0;

        for (int i = text.Length - 1; i >= 0; i--)
        {
            counter++;
            word.Append(text[i]);

            if (counter == 3)
            {
                string temp = "";

                for (int ch = 0; ch < 3; ch++)
                {
                    temp += word[2 - ch];
                }   
                            
                counter = allWords(temp,list);
                result += counter*(long)Math.Pow(13, powCounter);
                powCounter++;
                counter = 0;
                word.Clear();
            }
        }

        return result;
    }

    static void Main()
    {
        string text = Console.ReadLine();

        List<string> someSystem = new List<string>();
        someSystem.Add("CHU");
        someSystem.Add("TEL");
        someSystem.Add("OFT");
        someSystem.Add("IVA");
        someSystem.Add("EMY");
        someSystem.Add("VNB");
        someSystem.Add("POQ");
        someSystem.Add("ERI");
        someSystem.Add("CAD");
        someSystem.Add("K-A");
        someSystem.Add("IIA");
        someSystem.Add("YLO");
        someSystem.Add("PLA");

        long result = toDecimal(text,someSystem);

        Console.WriteLine(result);
    }
}

