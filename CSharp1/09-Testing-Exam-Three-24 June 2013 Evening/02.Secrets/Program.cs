using System;
using System.Numerics;

class Secrets
{
    static void Main()
    {
        BigInteger integerNumber = BigInteger.Parse(Console.ReadLine());
        if (integerNumber < 0)
        {
            integerNumber = -integerNumber;
        }
        BigInteger inputNumber = integerNumber;
        BigInteger specialSum = 0;
        int counter = 1;
        int numbersLength = integerNumber.ToString().Length;

        //find specialSum
        for (int i = 1; i <= numbersLength; i++)
        {
            if (counter % 2 == 0)
            {
                specialSum += (integerNumber % 10) * (integerNumber % 10) * i;
                integerNumber /= 10;
                counter++;              
            }
            else
            {
                specialSum += (integerNumber % 10) * (i * i);
                integerNumber /= 10;
                counter++;              
            }
        }

        Console.WriteLine(specialSum);
        if (specialSum % 10 == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", inputNumber);
        }
        else
        {
            //findAlphaSequince
            BigInteger numberR = specialSum % 26;
            string alphaSequince = "";
            BigInteger aphaNumber = numberR + 1;
            for (int i = 1; i <= specialSum % 10; i++)
            {
                if (aphaNumber == 1)
                {
                    alphaSequince += "A";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 2)
                {
                    alphaSequince += "B";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 3)
                {
                    alphaSequince += "C";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 4)
                {
                    alphaSequince += "D";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 5)
                {
                    alphaSequince += "E";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 6)
                {
                    alphaSequince += "F";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 7)
                {
                    alphaSequince += "G";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 8)
                {
                    alphaSequince += "H";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 9)
                {
                    alphaSequince += "I";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 10)
                {
                    alphaSequince += "J";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 11)
                {
                    alphaSequince += "K";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 12)
                {
                    alphaSequince += "L";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 13)
                {
                    alphaSequince += "M";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 14)
                {
                    alphaSequince += "N";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 15)
                {
                    alphaSequince += "O";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 16)
                {
                    alphaSequince += "P";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 17)
                {
                    alphaSequince += "Q";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 18)
                {
                    alphaSequince += "R";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 19)
                {
                    alphaSequince += "S";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 20)
                {
                    alphaSequince += "T";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 21)
                {
                    alphaSequince += "U";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 22)
                {
                    alphaSequince += "V";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 23)
                {
                    alphaSequince += "W";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 24)
                {
                    alphaSequince += "X";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 25)
                {
                    alphaSequince += "Y";
                    aphaNumber++;
                    continue;
                }
                if (aphaNumber == 26 && i < specialSum)
                {
                    alphaSequince += "Z";
                    aphaNumber = 1;
                    continue;
                }
                if (aphaNumber == 26 && i == specialSum)
                {
                    alphaSequince += "Z";
                    aphaNumber++;
                    continue;
                }

            }
            Console.WriteLine(alphaSequince);
        }

    }
}

