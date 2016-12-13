
namespace ArrayOfIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ArrayOfIntegers
    {
        public static int[] GenerateArray(int size)
        {
            int[] generatedArray = new int[size];
            Random rand = new Random();

            for (int i = 0; i < generatedArray.Length; i++)
            {
                generatedArray[i] = rand.Next(1, 120);
            }

            return generatedArray;
        }

        public static void Main()
        {
            //create array and fill it using our method for filling the array with random numbers
            int[] newArray = GenerateArray(100);

            //using Build-In Extension and lampda
            var findElements = Array.FindAll(newArray, x => x % 7 == 0 && x % 3 == 0);

            Console.WriteLine("Using Lampda");
            foreach (var element in findElements)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Using LINQ");
            //using LINQ 

            var findElementsLINQ =
                from number in newArray
                where number % 7 == 0 && number % 3 == 0
                select number;

            foreach (var number in findElementsLINQ)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
