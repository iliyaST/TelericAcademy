using System;
using System.Text;
using System.Numerics;

class Enigmanation
{
    static void Main()
    {
       
        String input = Console.ReadLine();     
        string currentOperator = "+";
        decimal Sum = 0;
        bool openBrakets = false;
        decimal subSum = 0;
        string currentBraketsOperator = "+";

        foreach (char symbol in input)
        {
            #region brakets
            if (openBrakets == true)
            {
                if ('0' <= symbol && symbol <= '9')
                {
                    if (currentBraketsOperator == "+")
                    {
                        subSum += symbol - '0';
                    }
                    if (currentBraketsOperator == "-")
                    {
                        subSum -= symbol - '0';
                    }
                    if (currentBraketsOperator == "*")
                    {
                        subSum *= symbol - '0';
                    }
                    if (currentBraketsOperator == "%")
                    {
                        subSum %= symbol - '0';
                    }
                }
                if (symbol == '+')
                {

                    currentBraketsOperator = "+";
                }
                if (symbol == '-')
                {

                    currentBraketsOperator = "-";
                }
                if (symbol == '*')
                {

                    currentBraketsOperator = "*";
                }
                if (symbol == '%')
                {

                    currentBraketsOperator = "%";
                }
                if (symbol == ')')
                {
                    if (currentOperator == "+")
                    {
                        Sum += subSum;
                    }
                    if (currentOperator == "-")
                    {
                        Sum -= subSum;
                    }
                    if (currentOperator == "*")
                    {
                        Sum *= subSum;
                    }
                    if (currentOperator == "%")
                    {
                        Sum %= subSum;
                    }
                    openBrakets = false;
                    subSum = 0;
                }
                continue;
            }
            #endregion
            #region out of brakets
            if ('0' <= symbol && symbol <= '9')
            {
                if (currentOperator == "+")
                {
                    Sum += symbol - '0';
                }
                if (currentOperator == "-")
                {
                    Sum -= symbol - '0';
                }
                if (currentOperator == "*")
                {
                    Sum *= symbol - '0';
                }
                if (currentOperator == "%")
                {
                    Sum %= symbol - '0';
                }
            }
            if (symbol == '+')
            {
                currentOperator = "+";
            }
            if (symbol == '-')
            {
                currentOperator = "-";
            }
            if (symbol == '*')
            {
                currentOperator = "*";
            }
            if (symbol == '%')
            {
                currentOperator = "%";
            }
            if (symbol == '(')
            {
                currentBraketsOperator = "+";
                openBrakets = true;
            }
            if (symbol == '=')
            {
                Console.WriteLine("{0:F3}", Sum);
                Environment.Exit(0);
            }
        }
        #endregion      
    }
}

