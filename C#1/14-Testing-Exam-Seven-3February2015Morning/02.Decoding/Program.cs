using System;

class Decoding
{
    static void Main()
    {
        int salt = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        int temp = 0;
        bool end = false;

        while (true)
        {
            if (end == true)
            {
                break;
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '@')
                {
                    end = true;
                    break;
                }
                else if (char.IsLetter(text[i]))
                {
                    temp = (text[i] * salt) + 1000;
                   
                }
                else if (char.IsDigit(text[i]))
                {
                    temp = text[i] + salt + 500;
                  
                }
                else
                {
                    temp = text[i] - salt;
                    
                }
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:F2}", (double)temp / 100);
                }
                else
                {
                    Console.WriteLine("{0}", temp * 100);
                }
            }
        }

    }
}

