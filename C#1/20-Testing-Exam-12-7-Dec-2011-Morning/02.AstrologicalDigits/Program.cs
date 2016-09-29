using System;

class AstrologicalDigits
{
    static void Main()
    {
        string N = Console.ReadLine();
        int sum = 0;

        for (int i = 0; i < N.Length; i++)
        {           
            if (char.IsDigit(N[i]))
            {
                sum += int.Parse(N[i].ToString());
            }
            if ((i == N.Length - 1) && sum > 9)
            {
                i = -1;
                N = sum.ToString();
                sum = 0;
            }
        }
        Console.WriteLine(sum);
    }
}

