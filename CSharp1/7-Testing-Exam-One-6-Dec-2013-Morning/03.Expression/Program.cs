using System;

class XXpression
{
    static void Main()
    {
        string expression = Console.ReadLine();
        double result = 0;
        double tempResult = 0;
        char currentOperrator = '+';
        bool currentBracker = false;
        char tempOperrator = '+';
        char helpOperator = '+';

        foreach (var symbol in expression)
        {
            if (currentBracker == true)
            {
                if (symbol >= '0' && symbol <= '9')
                {
                    if (tempOperrator == '+')
                    {
                        tempResult += symbol - '0';
                    }
                    if (tempOperrator == '/')
                    {
                        tempResult /= symbol - '0';
                    }
                    if (tempOperrator == '*')
                    {
                        tempResult *= symbol - '0';
                    }
                    if (tempOperrator == '-')
                    {
                        tempResult -= symbol - '0';
                    }
                }
            }
            else
            {
                if (symbol >= '0' && symbol <= '9')
                {
                    if (currentOperrator == '+')
                    {
                        result += symbol - '0';
                    }
                    if (currentOperrator == '/')
                    {
                        result /= symbol - '0';
                    }
                    if (currentOperrator == '*')
                    {
                        result *= symbol - '0';
                    }
                    if (currentOperrator == '-')
                    {
                        result -= symbol - '0';
                    }
                }
            }

            if (symbol == '+')
            {
                currentOperrator = '+';
                tempOperrator = '+';
            }
            if (symbol == '/')
            {
                currentOperrator = '/';
                tempOperrator = '/';
            }
            if (symbol == '*')
            {
                currentOperrator = '*';
                tempOperrator = '*';
            }
            if (symbol == '-')
            {
                currentOperrator = '-';
                tempOperrator = '-';
            }
            if (symbol == '(')
            {
                currentBracker = true;
                helpOperator = currentOperrator;
                tempOperrator = '+';
            }
            if (symbol == ')')
            {
                currentBracker = false;
                if (helpOperator == '+')
                {
                    result += tempResult;
                }
                if (helpOperator == '-')
                {
                    result -= tempResult;
                }
                if (helpOperator == '*')
                {
                    result *= tempResult;
                }
                if (helpOperator == '/')
                {
                    result /= tempResult;
                }
                tempResult = 0;
            }
            if (symbol == '=')
            {
                break;
            }
        }

        Console.WriteLine("{0:F2}", result);
    }
}



