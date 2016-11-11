using System;

class BinaryShort
{
    static string ShortToBinary(short number)
    {
        string toBinary = "";

        if (number >= 0)
        {
            toBinary = Convert.ToString(number, 2).PadLeft(16, '0');
            return toBinary;
        }
        else
        {
            string remainPart = Convert.ToString(32768 - (-number), 2).PadLeft(15, '0');
            string final = ("1" + remainPart).PadLeft(16, '0');
            return final;
        }
    }

    static void Main()
    {
        //short number = short.MaxValue;

        short number = short.Parse(Console.ReadLine());

        string result = ShortToBinary(number);

        Console.WriteLine(result);
    }
}

