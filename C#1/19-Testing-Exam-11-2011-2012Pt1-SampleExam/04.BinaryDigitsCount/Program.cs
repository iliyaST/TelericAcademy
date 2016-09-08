using System;

class BinaryDigitsCount
{
    static void Main()
    {
        int binaryDigit = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        int numberOfBinaryDigits = 0;

        for (int i = 0; i < N; i++)
        {
            long temp = long.Parse(Console.ReadLine());
            string numberInBinary = Convert.ToString(temp, 2);

            for (int j = 0; j < numberInBinary.Length; j++)
            {
                if (int.Parse(numberInBinary[j].ToString()) == binaryDigit)
                {
                    numberOfBinaryDigits++;
                }
            }
            Console.WriteLine(numberOfBinaryDigits);
            numberOfBinaryDigits = 0;
        }
    }
}

