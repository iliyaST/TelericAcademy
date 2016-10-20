using System;

class IndexOfLetters
{
    static void Main()
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if(input[i]==alphabet[j])
                {
                    Console.WriteLine(j);
                }
            }
        }
    }
}

