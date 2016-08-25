using System;
using System.Numerics;
public class Maslan
{
    public static void Main()
    {
        BigInteger randomPositiveNumber = BigInteger.Parse(Console.ReadLine());
        int transformations = 1;
        BigInteger product = 1;

        while (true)
        {
            randomPositiveNumber /= 10;
            string number = Convert.ToString(randomPositiveNumber);
            long currentSum = 0;

            for (int i = 1; i < number.Length; i += 2)
            {
                currentSum += Convert.ToInt64(number[i].ToString());
            }
            if (currentSum != 0)
            {
                product *= currentSum;
            }

            if (randomPositiveNumber < 1)
            {
                if (product > 9)
                {
                    randomPositiveNumber = product;
                    if (transformations == 10)
                    {
                        break;
                    }
                    transformations++;
                    product = 1;
                }
                else
                {
                    break;
                }
            }
        }

        if (transformations == 10)
        {
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine(transformations);
            Console.WriteLine(product);
        }
    }
}

