using System;

class OddNumber
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        long[] array = new long[N];
        int[] arCounter = new int[N];

        for (int i = 0; i < N; i++)
        {
            long temp = long.Parse(Console.ReadLine());
            array[i] = temp;
        }

        for (int i = 0; i < N; i++)
        {
            int counter = 0;
            for (int j = 0; j < N; j++)
            {
                if (array[i] == array[j])
                {
                    counter++;
                }
            }
            arCounter[i] = counter;
        }
           
        //for (int i = 0; i < N; i++)
        //{
        //    Console.Write(arCounter[i]+" ");
        //}
        //Console.WriteLine();

        //for (int i = 0; i < N; i++)
        //{
        //    int counter = 0;
        //    for (int j = 0; j < N; j++)
        //    {
        //        if(arCounter[i]==arCounter[j])
        //        {
        //            counter++;
        //        }
        //    }
        //    if(counter==arCounter[i])
        //    {
        //        Console.WriteLine(arCounter[i]);
        //        break;
        //    }
        //}
    }
}

