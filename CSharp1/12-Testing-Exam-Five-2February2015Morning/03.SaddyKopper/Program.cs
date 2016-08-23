using System;
using System.Numerics;
using System.IO;

class SaddyKopper
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        Console.SetIn(sr);

        string randomNumber = Console.ReadLine();
        long result = 0;
        BigInteger product = 1;
        int counter = 0;
        string copyNumber = "";
        int countTransformations = 0;

        while (countTransformations < 10)
        {
            for (int i = 0; i < randomNumber.Length - 1 - counter; i++)
            {
                copyNumber += randomNumber[i].ToString();
                if (i % 2 == 0)
                {
                    result += randomNumber[i] - '0';
                }
            }
            counter++;
            product *= result;
            result = 0;
            copyNumber = "";
            if (counter == randomNumber.Length - 1)
            {
                product *= result;
                Console.WriteLine(product);
                countTransformations++;
                break;
            }
        }
    }
}

