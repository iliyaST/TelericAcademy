using Generic;
using System;
namespace GenericClass
{
    using System;

    public class GenericListTest
    {
        public static void Main()
        {
            //this class is for testing purposes

            //Create Object from class GenericList using the constructor with given capacity
            GenericList<int> testList = new GenericList<int>(1);

            //adding some elements
            testList.AddElement(15);
            testList.AddElement(10);
            testList.AddElement(49);
            testList.AddElement(18);

            //testing indexator
            Console.WriteLine(testList[1]);
            testList[1] = 56;
            Console.WriteLine(testList[1]);

            //testing remove by index
            testList.RemoveElement(1);
            Console.WriteLine(testList[1]);
            testList.AddElement(1);
            testList.RemoveElement(testList.Count - 1);

            //inserting by index
            testList.InsertElement(0, 100);

            //testing element counter
            Console.WriteLine("Count: " + testList.Count);

            //find element
            Console.WriteLine(testList.FindElement(49));

            //to string
            Console.WriteLine(testList.ToString());

            testList.AddElement(1);
            testList.AddElement(1);
            testList.AddElement(1);
            testList.AddElement(1);
            testList.AddElement(1);
            testList.AddElement(1);

            //min & max element
            Console.WriteLine(testList.MinElement());
            Console.WriteLine(testList.MaxValue());

            //clearing the list
            testList.ClearList();
            Console.WriteLine();
        }
    }
}
