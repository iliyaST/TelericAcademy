using System;

class TribonacciTriangle
{
    static void Main()
    {
        long firstN = long.Parse(Console.ReadLine());
        long secondN = long.Parse(Console.ReadLine());
        long thirdN = long.Parse(Console.ReadLine());
        int numberL = int.Parse(Console.ReadLine());

        //print first 3 numbers of Tribonacci Sequince
        Console.WriteLine(firstN);
        Console.WriteLine("{0} {1}", secondN, thirdN);

        //print remaining numbers of Tribonacci Sequince
        //int a = 0;
        //int b = 1;
        //for (int i = 0; i < n; i++)
        //{
        //    int temp = a;
        //    a = b;
        //    b = temp + b;
        //}
        //return a;        
        for (int i = 3; i <= numberL; i++)
        {
            for (int x = 0; x < i; x++)
            {
                long temp = firstN;
                long temp1 = secondN;
                firstN = secondN;
                secondN = thirdN;
                thirdN += temp + temp1;
                if (x == i - 1)
                {
                    Console.Write(thirdN);
                }
                else
                {
                    Console.Write(thirdN + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

