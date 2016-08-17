using System;

class OnesAndZeros
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string inputNumber = Convert.ToString(n, 2).PadLeft(16, '0');
        string zero = "###\n#.#\n#.#\n#.#\n###";
        string one = ".#.\n##.\n.#.\n.#.\n###";


        for (int i = 0; i < inputNumber.Length; i++)
        {
            if(i==inputNumber.Length-1)
            {
                if (inputNumber[i] == '0')
                {
                    Console.Write("###");
                }
                if (inputNumber[i] == '1')
                {
                    Console.Write(".#.");
                }
                continue;
            }
            if (inputNumber[i] == '0')
            {
                Console.Write("###.");
            }
            if (inputNumber[i] == '1')
            {
                Console.Write(".#..");
            }
        }
        Console.WriteLine();
        for (int i = 0; i < inputNumber.Length; i++)
        {
            if (i == inputNumber.Length - 1)
            {
                if (inputNumber[i] == '0')
                {
                    Console.Write("#.#");
                }
                if (inputNumber[i] == '1')
                {
                    Console.Write("##.");
                }
                continue;
            }
            if (inputNumber[i] == '0')
            {
                Console.Write("#.#.");
            }
            if (inputNumber[i] == '1')
            {
                Console.Write("##..");
            }
        }
        Console.WriteLine();
        for (int i = 0; i < inputNumber.Length; i++)
        {
            if (i == inputNumber.Length - 1)
            {
                if (inputNumber[i] == '0')
                {
                    Console.Write("#.#");
                }
                if (inputNumber[i] == '1')
                {
                    Console.Write(".#.");
                }
                continue;
            }
            if (inputNumber[i] == '0')
            {
                Console.Write("#.#.");
            }
            if (inputNumber[i] == '1')
            {
                Console.Write(".#..");
            }
        }
        Console.WriteLine();
        for (int i = 0; i < inputNumber.Length; i++)
        {
            if (i == inputNumber.Length - 1)
            {
                if (inputNumber[i] == '0')
                {
                    Console.Write("#.#");
                }
                if (inputNumber[i] == '1')
                {
                    Console.Write(".#.");
                }
                continue;
            }
            if (inputNumber[i] == '0')
            {
                Console.Write("#.#.");
            }
            if (inputNumber[i] == '1')
            {
                Console.Write(".#..");
            }
        }
        Console.WriteLine();
        for (int i = 0; i < inputNumber.Length; i++)
        {
            if (i == inputNumber.Length - 1)
            {
                if (inputNumber[i] == '0')
                {
                    Console.Write("###");
                }
                if (inputNumber[i] == '1')
                {
                    Console.Write("###");
                }
                continue;
            }
            if (inputNumber[i] == '0')
            {
                Console.Write("###.");
            }
            if (inputNumber[i] == '1')
            {
                Console.Write("###.");
            }
        }
        Console.WriteLine();
    }
}

