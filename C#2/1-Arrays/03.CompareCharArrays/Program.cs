using System;

class CompareCharArrays
{
    static void Main()
    {
        string array1 = Console.ReadLine();
        string array2 = Console.ReadLine();

        if (array1.Length == array2.Length)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] > array2[i])
                {
                    Console.WriteLine(">");
                    Environment.Exit(0);
                }
                if (array1[i] < array2[i])
                {
                    Console.WriteLine("<");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("=");
        }
        else
        {
            for (int i = 0; i < Math.Min(array1.Length,array2.Length); i++)
            {
                if (array1[i] > array2[i])
                {
                    Console.WriteLine(">");
                    Environment.Exit(0);
                }
                if (array1[i] < array2[i])
                {
                    Console.WriteLine("<");
                    Environment.Exit(0);
                }
            }
            if (array1.Length > array2.Length)
            {
                Console.WriteLine(">");
                Environment.Exit(0);
            }
            if (array1.Length < array2.Length)
            {
                Console.WriteLine("<");
                Environment.Exit(0);
            }
        }
          
    }
}