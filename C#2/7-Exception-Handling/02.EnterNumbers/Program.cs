using System;

class EnterNumbers
{
    static int ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());

        if (number <= start || number >= end)
        {
            throw new ArgumentOutOfRangeException("Exeption");
        }
        else
        {
            return number;
        }
    }

    static void Main()
    {
        int start = 1;
        int end = 100;
        string result = "1 < ";
        int number = 0;

        for (int i = 0; i < 10; i++)
        {
            if (i == 9)
            {
                try
                {
                    number = ReadNumber(start, end);
                    start = number;
                    result += number.ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Exception");
                    Environment.Exit(0);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Exception");
                    Environment.Exit(0);
                }
                break;
            }
            try
            {
                number = ReadNumber(start, end);
                start = number;
                result += number.ToString() + " < ";
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Exception");
                Environment.Exit(0);
            }
            catch(FormatException)
            {
                Console.WriteLine("Exception");
                Environment.Exit(0);
            }
        }

        Console.WriteLine(result+" < 100");
    }
}

