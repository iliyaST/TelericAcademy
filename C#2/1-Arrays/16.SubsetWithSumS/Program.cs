using System;

class SubsetWithSumS
{
    static void Main()
    {

        float number1 = float.Parse(Console.ReadLine());
        float number2 = float.Parse(Console.ReadLine());
        float esp = 0.000001f;

        if (number2 < number1)
        {
            float temp = number2;
            number2 = number1;
            number1 = temp;
        }

        Console.WriteLine(number2 - number1 == esp);

    }

}


