using System;
using System.IO;

class TextToNumber
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../test.txt");
        Console.SetIn(sr);

        int numberM = int.Parse(Console.ReadLine());
        string someText = Console.ReadLine();

        long result = 0;

        foreach (char symbol in someText)
        {
            if (symbol == '@')
            {
                Console.WriteLine(result);
                break;
            }
            else if (char.IsDigit(symbol))
            {
                result *= symbol - '0';
            }
            else if (char.IsLetter(symbol))
            {
                switch (symbol)
                {
                    case 'A': result += 0; break;
                    case 'a': result += 0; break;
                    case 'B': result += 1; break;
                    case 'b': result += 1; break;
                    case 'C': result += 2; break;
                    case 'c': result += 2; break;
                    case 'D': result += 3; break;
                    case 'd': result += 3; break;
                    case 'E': result += 4; break;
                    case 'e': result += 4; break;
                    case 'F': result += 5; break;
                    case 'f': result += 5; break;
                    case 'G': result += 6; break;
                    case 'g': result += 6; break;
                    case 'H': result += 7; break;
                    case 'h': result += 7; break;
                    case 'I': result += 8; break;
                    case 'i': result += 8; break;
                    case 'J': result += 9; break;
                    case 'j': result += 9; break;
                    case 'K': result += 10; break;
                    case 'k': result += 10; break;
                    case 'L': result += 11; break;
                    case 'l': result += 11; break;
                    case 'M': result += 12; break;
                    case 'm': result += 12; break;
                    case 'N': result += 13; break;
                    case 'n': result += 13; break;
                    case 'O': result += 14; break;
                    case 'o': result += 14; break;
                    case 'P': result += 15; break;
                    case 'p': result += 15; break;
                    case 'Q': result += 16; break;
                    case 'q': result += 16; break;
                    case 'R': result += 17; break;
                    case 'r': result += 17; break;
                    case 'S': result += 18; break;
                    case 's': result += 18; break;
                    case 'T': result += 19; break;
                    case 't': result += 19; break;
                    case 'U': result += 20; break;
                    case 'u': result += 20; break;
                    case 'V': result += 21; break;
                    case 'v': result += 21; break;
                    case 'W': result += 22; break;
                    case 'w': result += 22; break;
                    case 'X': result += 23; break;
                    case 'x': result += 23; break;
                    case 'Y': result += 24; break;
                    case 'y': result += 24; break;
                    case 'Z': result += 25; break;
                    case 'z': result += 25; break;
                }
            }
            else
            {
                result %= numberM;
            }

        }
    }
}

