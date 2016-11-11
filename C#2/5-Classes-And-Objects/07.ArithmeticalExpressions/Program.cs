using System;

class ArithmeticalExpressions
{
    static double Brackets(int i, string expression, string currentSign)
    {
        double currentSum = 0;
        double temp;

        for (int z = i + 1; z < expression.Length; z++)
        {
            if (expression[z] == ')')
            {
                return currentSum;
            }

            if (double.TryParse(expression[z].ToString(), out temp))
            {
                if (currentSign == "+")
                {
                    currentSum += temp;
                }
                else if (currentSign == "-")
                {
                    currentSum -= temp;
                }
                else if (currentSign == "*")
                {
                    currentSum *= temp;
                }
                else if (currentSign == "/")
                {
                    currentSum /= temp;
                }
                continue;
            }

            if (expression[z] == '+')
            {
                currentSign = "+";
                continue;
            }
            else if (expression[z] == '-')
            {
                currentSign = "-";
                continue;
            }
            else if (expression[z] == '*')
            {
                currentSign = "*";
                continue;
            }
            else if (expression[z] == '/')
            {
                currentSign = "/";
                continue;
            }
            else if (expression[z] == '(')
            {
                Brackets(z, expression, currentSign);
            }

        }
        return currentSum;
    }

    static void Main()
    {
        string expression = Console.ReadLine();
        string currentSign = "+";

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                Brackets(i, expression, currentSign);
            }
        }

    }
}

