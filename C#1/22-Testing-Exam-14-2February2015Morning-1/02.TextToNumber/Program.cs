using System;

class TextToNumber
{
    static void Main()
    {
        int M = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        int result = 0;

        foreach (var symbol in text)
        {
            if (symbol == '@')
            {
                Console.WriteLine(result);
                Environment.Exit(0);
            }
            else if (char.IsDigit(symbol))
            {
                result *= Convert.ToInt32(symbol.ToString());
            }
            else if (char.IsLetter(symbol))
            {
                if (symbol >= 65 && symbol <= 90)
                {
                    result += symbol - 65;
                }
                else
                {
                    result += symbol - 97;
                }
            }
            else
            {
                result %= M;
            }
        }
    }
}

