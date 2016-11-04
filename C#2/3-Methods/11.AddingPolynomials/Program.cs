using System;
using System.Collections.Generic;

class AddingPolynomials
{
    static void SumOfPolynomials(List<int> firstArray, List<int> secondArray,List<int> sumList)
    {
        for (int i = 0; i < firstArray.Count; i++)
        {
            sumList.Add(firstArray[i] + secondArray[i]);
        }
    }


    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        List<int> firstArray = new List<int>();
        List<int> secondArray = new List<int>();
        List<int> sumList = new List<int>();

        string[] firstPolynom = Console.ReadLine().Split(new char[] { ' ' });
        string[] secondPolynom = Console.ReadLine().Split(new char[] { ' ' });

        for (int i = 0; i < firstPolynom.Length; i++)
        {
            firstArray.Add(int.Parse(firstPolynom[i]));
        }
        for (int i = 0; i < secondPolynom.Length; i++)
        {
            secondArray.Add(int.Parse(secondPolynom[i]));
        }

        SumOfPolynomials(firstArray,secondArray,sumList);

        for (int i = 0; i < sumList.Count; i++)
        {
            Console.Write(sumList[i]+" ");
        }

        Console.WriteLine();
    }
}

