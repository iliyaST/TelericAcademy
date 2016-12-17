
namespace RangeExeptions
{
    using System;
    using System.Globalization;

    public class InvalidExeptionTest
    {
            /// <summary>
            /// Reads number from console.
            /// </summary>
        public static void ReadNumber()
        {
            int min = 1;
            int max = 100;

            Console.Write("Enter a number in range [{0},{1}]: ", min, max);
            int number = int.Parse(Console.ReadLine());
            if (number >= min && number <= max)
            {
                Console.WriteLine("Number is in range.");
            }
            else
            {
                throw new InvalidRangeException<int>(min, max);
            }
        }

        /// <summary>
        /// Reads date from console.
        /// </summary>
        public static void ReadDate()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("bg-BG");

            DateTime min = new DateTime(1980, 1, 1);
            DateTime max = new DateTime(2013, 12, 31);

            Console.Write("Enter a date in range [{0:dd/MM/yyyy}, {1:dd/MM/yyyy}]: ", min, max);
            DateTime date = DateTime.Parse(Console.ReadLine());

            if (date.CompareTo(min) > 0 && date.CompareTo(max) < 0)
            {
                Console.WriteLine("Date is in range.");
            }
            else
            {
                throw new InvalidRangeException<DateTime>(min, max);
            }
        }

        static void Main()
        {
            //For a very cool way of solving this problem check ivaylokenov's repository.
            try
            {
                while (true)
                {
                    ReadNumber();
                    ReadDate();
                }
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine(ire.Message);
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine(ire.Message);
            }
        }
    }
}
