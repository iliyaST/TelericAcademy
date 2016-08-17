using System;

class PeaceOfCake
{
    static void Main()
    {
        //input
        long A = long.Parse(Console.ReadLine());
        long B = long.Parse(Console.ReadLine());
        long C = long.Parse(Console.ReadLine());
        long D = long.Parse(Console.ReadLine());
    
        //find num and denum and sumOfFractions
        decimal sumOfFractions = (decimal)(A * D + C * B) / (B * D);
        long numinator = (A * D + C * B);
        long denuminator = B * D;

        //Print
        if (sumOfFractions < 1)
        {
            Console.WriteLine("{0:F22}", sumOfFractions);
            Console.WriteLine("{0}/{1}", numinator, denuminator);
        }
        else
        {
            Console.WriteLine("{0}", (int)sumOfFractions);
            Console.WriteLine("{0}/{1}", numinator, denuminator);
        }

    }
}

