using System;

class AllovateArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] Array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Array[i] = i*5;
            Console.WriteLine(Array[i]);
        }      
    }
}

