
namespace IEnumerableExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionsForIEnumerable
    {

        /// <summary>
        /// Create Extension for the Sum of the elements in some collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static T Sum<T>(this IEnumerable<T> numbers) where T : IComparable, IFormattable, IConvertible
        {
            //check if we have elements in our collection
            if (numbers.FirstOrDefault() == null)
            {
                throw new ArgumentException("U dont have any elements!");
            }

            //create a variable sum dynamic because u have unknown type of elements
            dynamic sum = 0;

            //get every element and sum it 
            foreach (var element in numbers)
            {
                sum += element;
            }

            //return the sum
            return sum;
        }

        //product of elements
        public static T Product<T>(this IEnumerable<T> elements)
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T product = (dynamic)1;

            foreach (var item in elements)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        //minimum of elements
        public static T Min<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T minValue = elements.First();

            foreach (var item in elements)
            {
                if (item < (dynamic)minValue)
                {
                    minValue = item;
                }
            }

            return minValue;
        }

        //max elements
        public static T Max<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T maxValue = elements.First();

            foreach (var element in elements)
            {
                if (element > (dynamic)maxValue)
                {
                    maxValue = element;
                }
            }

            return maxValue;
        }

        //average
        public static decimal Average<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T sumOfValues = (dynamic)0;
            int numberOfElements = 0;

            foreach (var item in elements)
            {
                sumOfValues += (dynamic)item;
                numberOfElements++;
            }

            return (dynamic)sumOfValues / (decimal)numberOfElements;
        }
    }
}
