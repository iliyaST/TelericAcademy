
namespace _03.CorrectBrackets
{
    using System;

    class Correctbrackets
    {
        static bool checkBrackets(string text)
        {
            int counterOpenBrackets = 0;
            int counterClosedBrackets = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    counterOpenBrackets++;
                }
                if (text[i] == ')')
                {
                    counterClosedBrackets++;
                }
            }

            if (counterClosedBrackets == counterOpenBrackets)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static void Main()
        {
            string expression = Console.ReadLine();

            if (checkBrackets(expression))
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }
    }
}
