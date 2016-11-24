using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Program
{
    static BigInteger ConvertToDecimal(string number, int numeralBase)
    {
        BigInteger result = 0;
        foreach (char digit in number)
        {
            result = result * numeralBase + (digit - '0');

        }
        return result;
    }
    static BigInteger ConvertToDecimal2(List<string> number, int numeralBase)
    {
        BigInteger result = 0;
        foreach (string digit in number)
        {
            result = result * numeralBase + int.Parse(digit);

        }
        return result;
    }


    static BigInteger ConvertAzbukaToDec(string number, int baza = 10)
    {
        List<string> resultAlphabetToDec = new List<string>();

        string azbuka = "abcdefghijklmnopqrstuvwxyz";
        for (int letter = 0; letter < number.Length; letter++)
        {

            for (int i = 0; i < azbuka.Length; i++)
            {
                char digit = azbuka[i];
                if (digit == number[letter])
                {
                    resultAlphabetToDec.Add(i.ToString());
                }
            }
        }
        BigInteger result = ConvertToDecimal2(resultAlphabetToDec, 26);
        return result;

    }

    static string FromDecTo(BigInteger value, int numeralBase)
    {                               //
        string result = "";

        do
        {
            BigInteger digit = value % numeralBase;
            value /= numeralBase;

            result = digit + result;

        } while (value > 0);

        return result;
    }

    static void Main(string[] args)
    {
        string firstNumber = Console.ReadLine();
        string sign = Console.ReadLine();
        string secondNumber = Console.ReadLine();

        BigInteger firstConverted = ConvertAzbukaToDec(firstNumber);
        BigInteger secondConverted = ConvertToDecimal(secondNumber, 7);
        BigInteger result = 0;

        if (sign == "+")
        {
            result = firstConverted + secondConverted;
        }
        else
        {
            result = firstConverted - secondConverted;
        }

        string final = FromDecTo(result, 9);
        Console.WriteLine(final);
    }
}