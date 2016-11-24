using System;
using System.Collections.Generic;
using System.Numerics;

class TRES4Numbers
{
    static void Main()
    {
        BigInteger input = BigInteger.Parse(Console.ReadLine());

        List<string> list = new List<string>();

        list.Add("LON+");
        list.Add("VK-");
        list.Add("*ACAD");
        list.Add("^MIM");
        list.Add("ERIK|");
        list.Add("SEY&");
        list.Add("EMY>>");
        list.Add("/TEL");
        list.Add("<<DON");

        string resulted = "";

        while (input > 0)
        {
            resulted += (input % 9).ToString();
            input /= 9;
        }
        if (resulted == "")
        {
            resulted += '0';
        }

        string result = "";

        for (int i = resulted.Length - 1; i >= 0; i--)
        {
            switch (resulted[i])
            {
                case '0': Console.Write(list[0]); break;
                case '1': Console.Write(list[1]); break;
                case '2': Console.Write(list[2]); break;
                case '3': Console.Write(list[3]); break;
                case '4': Console.Write(list[4]); break;
                case '5': Console.Write(list[5]); break;
                case '6': Console.Write(list[6]); break;
                case '7': Console.Write(list[7]); break;
                case '8': Console.Write(list[8]); break;
            }
        }

        Console.WriteLine();
    }
}

