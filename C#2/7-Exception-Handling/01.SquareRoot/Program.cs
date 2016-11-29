using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            double number = double.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Console.WriteLine("{0:F3}", Math.Sqrt(number));
            }
        }
        catch
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}

