using System;
using System.IO;

class EncodingSUm
{
    static void Main()
    {

        StreamReader sr = new StreamReader("../../input.txt");
        Console.SetIn(sr);

        int numberM = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        long result = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '@')
            {
                break;

            }
            else if (char.IsDigit(text[i]))
            {
                result *= Convert.ToInt64(text[i].ToString());

            }
            else if (char.IsLetter(text[i]))
            {
                if(Convert.ToInt64(text[i])>=65&& Convert.ToInt64(text[i]) <= 90)
                {
                    result += Convert.ToInt64(text[i]) - 65;
                }
                if (Convert.ToInt64(text[i]) >= 97 && Convert.ToInt64(text[i]) <= 122)
                {
                    result += Convert.ToInt64(text[i]) - 97;
                }
                //A-Z - 65-90
                //a-z - 97-122
            }
            else
            {
                result %= numberM;
            }
        }
        Console.WriteLine(result);
    }
}

