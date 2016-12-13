
namespace IEnumerableExtensionMethods
{
    using System;
    using System.Collections.Generic;

    public class ExtensionsForIEnumerableTest
    {
        public static void Main()
        {
            //Testing
            List<int> list = new List<int>();

            int counter = 3;

            while (counter > 0)
            {
                list.Add(counter);
                counter--;
            }


            Console.WriteLine("Elements are: ");
            foreach (var element in list)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();

            int sum = list.Sum();
            Console.WriteLine("Sum of Elements in our collection is: {0}", sum);
            int product = list.Product();
            Console.WriteLine("Product of Elements in our collection is: {0}", product);
            int maxElement = list.Max();
            Console.WriteLine("Max element is {0}", maxElement);
            int minElement = list.Min();
            Console.WriteLine("Min element is {0}", minElement);
            decimal average = list.Average();
            Console.WriteLine("The Average of Elements in our collection is: {0}", average);

        }
    }
}
