using System;

class Feathers
{
    static void Main()
    {
        int B = int.Parse(Console.ReadLine());
        int F = int.Parse(Console.ReadLine());

        double averege = F / (double)B;
        double result = 0;

        if (B % 2 == 0)
        {
            result = averege * 123123123123.0;
        }
        else
        {
            result = averege / 317.0;
        }

        Console.WriteLine("{0:F4}",result);
    }
}

