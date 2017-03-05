namespace Task_2_Statistics
{
    using System;
    using System.Collections.Generic;

    class Statistics
    {
        public static void Main(string[] args)
        {
            double[] numbers = { 3.2, 14, 1, 8, 4.1, 9.17, 35 };
            PrintStatistics(numbers);
        }

        public static void PrintStatistics(double[] numbers)
        {
            Console.WriteLine(GetMaxNumber(numbers));
            Console.WriteLine(GetMinNumber(numbers));
            Console.WriteLine(GetAvarageNumber(numbers));
        }

        public static double GetMaxNumber(double[] numbers)
        {
            double maxNumber = double.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }

        public static double GetMinNumber(double[] numbers)
        {
            double minNumber = double.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            return minNumber;
        }

        public static double GetAvarageNumber(double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            double avarageValue = sum / numbers.Length;
            return avarageValue;
        }
    }
}
