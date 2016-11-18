using System;

class SquareRootMethods
{
    static void SQRT(int number)
    {
        int sqrt = 0;

        if (number < 0)
        {
            throw new FormatException("The number must not be negative!");
        }
        else
        {
            sqrt = (int)Math.Sqrt(number);
        }

        Console.WriteLine(sqrt);
    }

    static void Main()
    {
        try
        {
            int number = int.Parse(Console.ReadLine());
            SQRT(number);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number.");
        }
        finally
        {
            Console.WriteLine("Good bye.");
        }

    }
}

