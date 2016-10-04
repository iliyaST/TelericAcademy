using System;
using System.Numerics;

class SaddyKopper
{
    static void Main()
    {
        string randomN = Console.ReadLine();
        int counter = 1;
        long currentSum = 0;
        BigInteger totalSum = 1;
        int numberOfTransformations = 0;

        while (true)
        {
            for (int i = 0; i < randomN.Length - counter; i += 2)
            {
                currentSum += Convert.ToInt64(randomN[i].ToString());
            }
            counter++;

            if (currentSum != 0)
            {
                totalSum *= currentSum;
                currentSum = 0;
            }
            if (numberOfTransformations == 10)
            {
                Console.WriteLine(randomN);
                break;
            }

            if (counter == randomN.Length && totalSum > 9)
            {
                counter = 1;
                randomN = totalSum.ToString();
                totalSum = 1;
                numberOfTransformations++;
            }
            else if (counter == randomN.Length && totalSum < 10)
            {
                numberOfTransformations++;
                Console.WriteLine(numberOfTransformations);
                Console.WriteLine(totalSum);
                break;
            }
        }

    }
}