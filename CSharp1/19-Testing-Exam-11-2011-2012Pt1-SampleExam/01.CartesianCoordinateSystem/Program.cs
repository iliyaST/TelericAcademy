using System;
using System.Numerics;

class CartesianCoordinateSystem
{
    static void Main()
    {
        BigInteger x = BigInteger.Parse(Console.ReadLine());
        BigInteger y = BigInteger.Parse(Console.ReadLine());

        if (x == 0 && y == 0)
        {
            Console.WriteLine(0);
        }
        else if (x == 0 && y != 0)
        {
            Console.WriteLine(5);
        }
        else if (x != 0 && y == 0)
        {
            Console.WriteLine(6);
        }
        else if (x > 0 && y > 0)
        {
            Console.WriteLine(1);
        }
        else if (x < 0 && y > 0)
        {
            Console.WriteLine(2);
        }
        else if (x < 0 && y < 0)
        {
            Console.WriteLine(3);
        }
        else if(x>0&&y<0)
        {
            Console.WriteLine(4);
        }

    }
}

