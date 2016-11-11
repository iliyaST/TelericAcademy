using System;

class BinaryToHexadecimal
{
    static string BinaryToHex(string binaryNumber)
    {
        int len = binaryNumber.Length;  // 7  9  8
        int howManyNumbersInHex = len / 4; // 7 /  4 = 1  9 / 4 = 2 8/4 = 2
        int remain = len % 4;// 7 % 4 = 3   9 % 4 = 1   8 % 4 = 0
        int counter = 0;
        string binaryToHex = "";
        string temp = "";

        if (remain != 0)
        {
            len += 4 - remain;
        }

        string newBinaryNumber = binaryNumber.PadLeft(len, '0');

        for (int i = 0; i < len; i++)
        {
            temp += newBinaryNumber[i];
            counter++;
            if (counter == 4)
            {
                switch (temp)
                {
                    case "0000": binaryToHex += "0"; break;
                    case "0001": binaryToHex += "1"; break;
                    case "0010": binaryToHex += "2"; break;
                    case "0011": binaryToHex += "3"; break;
                    case "0100": binaryToHex += "4"; break;
                    case "0101": binaryToHex += "5"; break;
                    case "0110": binaryToHex += "6"; break;
                    case "0111": binaryToHex += "7"; break;
                    case "1000": binaryToHex += "8"; break;
                    case "1001": binaryToHex += "9"; break;
                    case "1010": binaryToHex += "A"; break;
                    case "1011": binaryToHex += "B"; break;
                    case "1100": binaryToHex += "C"; break;
                    case "1101": binaryToHex += "D"; break;
                    case "1110": binaryToHex += "E"; break;
                    case "1111": binaryToHex += "F"; break;
                }
                temp = "";
                counter = 0;
            }
        }

        return binaryToHex;
    }

    static void Main()
    {
        string binaryNumber = Console.ReadLine();

        string binaryToHex = BinaryToHex(binaryNumber);

        Console.WriteLine(binaryToHex);
    }
}

