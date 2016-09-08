using System;
/*
Problem 11.* Number as Words
Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.
*/
class Program
{
    static void Main()
    {
        string[] smallNumbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] mediumNumbers = { "ten", "eleven", "twelve", "thrirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] bignumbers = { "", "", "twenty", "thirty", "forty", "fifthy", "sixty", "seventy", "eighty", "ninety" };
        string[] hugeNumbers = { "hundred" };
        Console.WriteLine("Insert Number in range [0..999] Please:");
        string number = Console.ReadLine();
        int number1;
        int from10to19 = 10;

        if (int.TryParse(number, out number1))
        {
            if (Convert.ToInt32(number) < 0 || Convert.ToInt32(number) > 999)
            {
                Console.WriteLine("rong input");
            }
            if (Convert.ToInt32(number) < 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (Convert.ToInt32(number) == i)
                    {
                        Console.WriteLine(smallNumbers[i]);
                    }
                }
            }
            if (Convert.ToInt32(number) > 9 && Convert.ToInt32(number) < 20)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (Convert.ToInt32(number) == from10to19)
                    {
                        Console.WriteLine(mediumNumbers[i]);
                    }
                    from10to19++;
                }
            }
            if (Convert.ToInt32(number) > 19 && Convert.ToInt32(number) < 100)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (Convert.ToInt32(number) / 10 == i)
                    {
                        Console.Write(bignumbers[i]);
                        for (int j = 1; j < 10; j++)
                        {
                            if (Convert.ToInt32(number) % 10 == j)
                            {
                                Console.Write(" " + smallNumbers[j]);
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            if (Convert.ToInt32(number) == 100)
            {
                Console.WriteLine("one hundred");
            }
            if (Convert.ToInt32(number) > 100)
            {
                if (((Convert.ToInt32(number) / 10) % 10) == 0)
                {
                    for (int x = 1; x < 10; x++)
                    {
                        if (((Convert.ToInt32(number) / 100) % 10 == x))
                        {
                            Console.Write(smallNumbers[x] + " hundred ");
                        }
                    }
                    for (int y = 1; y < 10; y++)
                    {
                        if (Convert.ToInt32(number) % 10 == y)
                        {
                            Console.Write("and " + smallNumbers[y]);
                        }
                    }
                    Console.WriteLine();
                }
                if (((Convert.ToInt32(number) / 10) % 10) > 0)
                {
                    if ((((Convert.ToInt32(number)) / 10 % 10) * 10 + Convert.ToInt32(number) % 10) > 9 && (((Convert.ToInt32(number)) / 10 % 10) * 10 + Convert.ToInt32(number) % 10) < 20)
                    {
                        for (int x = 1; x < 10; x++)
                        {
                            if (((Convert.ToInt32(number) / 100) % 10 == x))
                            {
                                Console.Write(smallNumbers[x] + " hundred ");
                            }
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            if ((((Convert.ToInt32(number)) / 10 % 10) * 10 + Convert.ToInt32(number) % 10) == from10to19)
                            {
                                Console.Write("and " + mediumNumbers[i]);
                            }
                            from10to19++;
                        }
                        Console.WriteLine();
                    }
                    if ((((Convert.ToInt32(number)) / 10 % 10) * 10 + Convert.ToInt32(number) % 10) > 19)
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            if (((Convert.ToInt32(number) / 100) % 10) == i)
                            {
                                Console.Write(smallNumbers[i] + " hundred");
                            }
                        }
                        for (int x = 2; x < 10; x++)
                        {
                            if (((Convert.ToInt32(number) / 10) % 10) == x)
                            {
                                Console.Write(" and " + bignumbers[x]);
                            }
                        }
                        for (int z = 1; z < 10; z++)
                        {
                            if ((Convert.ToInt32(number) % 10) == z)
                            {
                                Console.WriteLine(" " + smallNumbers[z]);
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("rong input");
        }
    }
}




