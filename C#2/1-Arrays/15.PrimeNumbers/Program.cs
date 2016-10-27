using System;
using System.Collections.Generic;
using System.Numerics;

class PrimeNumbers
{
    static void Main()
    {
        // with FOR CYCLES
        //-------------------------------------------
        //int numberN = int.Parse(Console.ReadLine());
        //List<int> notPrime = new List<int>();

        //for (int i = 2; i <= numberN; i++)
        //{
        //    for (int y = i * 2; y <= numberN; y += i)
        //    {
        //        if (!notPrime.Contains(y))
        //        {
        //            notPrime.Add(y);
        //        }
        //    }
        //}

        //for (int i = numberN; i >= 0; i--)
        //{
        //    if (!notPrime.Contains(i))
        //    {
        //        Console.WriteLine(i);
        //        break;
        //    }
        //}
        //WITH FOR CYCLES
        //-------------------------------------
        //Other Solution


        long numberN = long.Parse(Console.ReadLine());
        bool[] e = new bool[numberN+1];//by default they're all false
        for (int i = 2; i <= numberN; i++)
        {
            e[i] = true;//set all numbers to true
        }
        //weed out the non primes by finding mutiples 
        for (int j = 2; j <= numberN; j++)
        {
            if (e[j])//is true
            {
                for (long p = 2; (p * j) <= numberN; p++)
                {
                    e[p * j] = false;
                }
            }
        }

        for (long i = numberN; i >= 0; i--)
        {
            if(e[i]==true)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}