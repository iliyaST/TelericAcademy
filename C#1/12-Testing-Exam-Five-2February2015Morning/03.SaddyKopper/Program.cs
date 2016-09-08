using System;
using System.Numerics;
using System.IO;

class SaddyKopper
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        Console.SetIn(sr);
        BigInteger input = BigInteger.Parse(Console.ReadLine());
        BigInteger product = 1;
        int numberOfTransformations = 1;

        while (true)
        {
            long currentResult = 0;
            input /= 10;
            string randomNumber = Convert.ToString(input);
            for (int i = 0; i < randomNumber.Length; i += 2)
            {
                currentResult += Convert.ToInt64((randomNumber[i]).ToString());
            }

            product *= currentResult;

            if (input / 10 < 1)
            {
                if (product > 9)
                {
                    if (numberOfTransformations == 10)
                    {
                        break;
                    }
                    numberOfTransformations++;
                    input = product;
                    product = 1;                    
                }
                else
                {
                    break;
                }
            }
        }
        if (numberOfTransformations == 10)
        {
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine(numberOfTransformations);
            Console.WriteLine(product);
        }
    }
}

