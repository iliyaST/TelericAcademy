using System;

class TripleRotationOfDigits
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        string number = Convert.ToString(input);
        string result = "";

        if (Convert.ToInt64(number) < 10)
        {
            Console.WriteLine(input);
        }
        else if (Convert.ToInt64(number) < 100)
        {
            result = Convert.ToString(input / 10);
            for (int i = 0; i < 1; i++)
            {
                result = number[number.Length - 1] + result;
            }
            Console.WriteLine(Convert.ToInt64(result));
        }
        else
        {
            if (Convert.ToInt64(number) < 1000)
            {
                result = Convert.ToString(input);
            }
            else
            {
                result = Convert.ToString(input / 1000);
                for (int i = 0; i < 3; i++)
                {
                    result = number[number.Length - 1 - i] + result;
                    long result1 = Convert.ToInt64(result);
                    result = Convert.ToString(result1);
                }
            }
            if (Convert.ToInt64(number) < 1000)
            {
                Console.WriteLine(Convert.ToInt64(result) );
            }
            else
            {
                Console.WriteLine(Convert.ToInt64(result));
            }
        }
    }
}

