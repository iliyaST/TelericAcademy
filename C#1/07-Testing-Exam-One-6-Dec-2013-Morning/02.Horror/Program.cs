using System;

class TheHorror
{
    static void Main()
    {
        string input = Console.ReadLine();
        long sum = 0;
        long counter = 0;
        long input1;

        for (int i = 0; i < input.Length; i += 2)
        {
            if (long.TryParse(input[i].ToString(), out input1))
            {
                sum += input[i] - '0';
                counter++;
            }
        }
        Console.WriteLine("{0} {1}", counter, sum);

    }
}