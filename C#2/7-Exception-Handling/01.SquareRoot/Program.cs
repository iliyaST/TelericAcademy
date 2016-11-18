using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Console.WriteLine(Math.Sqrt(number));
            }
        }
        catch
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good Bye.");
        }      
    }
}

