namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides of a triangle cannot be zero or less!");
            }

            if (a > b + c || b > a + c || c > a + b)
            {
                throw new ArgumentException("Sides cannot form a triangle!");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static string DigitToText(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid input");
            }
        }

        public static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Array must not be null or contain 0 elements");
            }

            var maxNumber = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }

        public static void PrintAsNumber(object number, string format)
        {
            try
            {
                if (format == "f")
                {
                    Console.WriteLine("{0:f2}", number);
                }

                if (format == "%")
                {
                    Console.WriteLine("{0:p0}", number);
                }

                if (format == "r")
                {
                    Console.WriteLine("{0,8}", number);
                }
            }
            catch (FormatException)
            {
                throw new FormatException("Input is not in valid number format!");
            }
        }

        public static double CalcDistanceBetweenTwoPoints(double firstPointX, double firstPointY, double secondPointX, double secondPointY, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = firstPointY == secondPointY;
            isVertical = firstPointX == secondPointX;

            double distance = Math.Sqrt(((secondPointX - firstPointX) * (secondPointX - firstPointX)) + ((secondPointY - firstPointY) * (secondPointY - firstPointY)));
            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToText(5));

            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalcDistanceBetweenTwoPoints(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
