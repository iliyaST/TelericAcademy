using System;

class BinarySearch
{
    static void Main()
    {

        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        int[] array = new int[N];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);

        int index = Array.BinarySearch(array, K);

        if (array[0] > index)
        {
            Console.WriteLine("There is no such element");
        }
        else
        {
            if (index < 0)
            {
                index = (~index) -1 ;
                Console.WriteLine(array[index]);
            }
            else
            {
                Console.WriteLine(array[index]);
            }
        }
    }
}

