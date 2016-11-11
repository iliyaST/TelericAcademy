using System;

class BinaryFloatingPoint
{
    static void BinaryToFloat(double number)
    {
        int integerPartOfNumber = 0;
        string resultSign = "";

        if (number < 0)
        {
            resultSign = "1";
        }
        else
        {
            resultSign = "0";
        }

        if (number < 0)
        {
            integerPartOfNumber = (int)(-number);
            number = -number;
        }
        else
        {
            integerPartOfNumber = (int)(number);
        }
        string binaryRepOfIntegerPart = Convert.ToString(integerPartOfNumber, 2);
        int pow = binaryRepOfIntegerPart.Length - 1;

        double floatingPart = number - integerPartOfNumber;
        string binaryFloatingPart = "";

        string exponent = "";
        string mantissa = "";

        exponent = Convert.ToString(pow + 127, 2);

        while (floatingPart > 0)
        {
            floatingPart *= 2;

            if (((int)(floatingPart % 2) == 0))
            {
                binaryFloatingPart += "0";
            }
            else
            {
                binaryFloatingPart += "1";
            }

            int tempInteger = (int)floatingPart;
            floatingPart = floatingPart - tempInteger;
        }

        string finalForm = "";

        finalForm += Convert.ToString(integerPartOfNumber, 2) + "." + binaryFloatingPart;

        string resultMantissa = "";

        for (int i = 1; i < finalForm.Length; i++)
        {
            if (finalForm[i] =='.')
            {
                continue;
            }
            resultMantissa += finalForm[i];
        }

        mantissa = resultMantissa.PadRight(23, '0');

        string theBinaryRepresentation = resultSign + "|" + exponent + "|" + mantissa;


        Console.WriteLine(theBinaryRepresentation);
    }

    static void Main()
    {
        double number = double.Parse(Console.ReadLine());

        BinaryToFloat(number);
    }
}

