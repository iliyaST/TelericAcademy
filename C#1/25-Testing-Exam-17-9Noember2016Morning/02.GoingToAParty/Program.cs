using System;

class GoingToAParty
{
    static void Path(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '^')
            {
                Console.WriteLine("Djor and Djano are at the party at {0}!", i);
                break;
            }
            else
            {
                if (input[i] <= 122 && input[i] >= 97)
                {
                    i += (input[i] - 97);

                    if (i + 1 >= input.Length || i + 1 < 0)
                    {
                        Console.WriteLine("Djor and Djano are lost at {0}!", i + 1);
                        break;
                    }
                }
                else if (input[i] >= 65 && input[i] <= 90)
                {
                    int iss = input[i] - 65+2;
                    i += (-iss);

                    if (i + 1 >= input.Length || i + 1 < 0)
                    {
                        Console.WriteLine("Djor and Djano are lost at {0}!", i + 1);
                        break;
                    }
                }
            }
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();

        Path(input);
    }
}

