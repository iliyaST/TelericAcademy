using System;
using System.IO;

class MissCat2011
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        Console.SetIn(sr);

        int numberOfJudges = int.Parse(Console.ReadLine());
        int cat1 = 0;
        int cat2 = 0;
        int cat3 = 0;
        int cat4 = 0;
        int cat5 = 0;
        int cat6 = 0;
        int cat7 = 0;
        int cat8 = 0;
        int cat9 = 0;
        int cat10 = 0;
        int max = 0;

        for (int i = 0; i < numberOfJudges; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            switch (temp)
            {
                case 1: cat1++; if (max < cat1) { max = cat1; } break;
                case 2: cat2++; if (max < cat2) { max = cat2; } break;
                case 3: cat3++; if (max < cat3) { max = cat3; } break;
                case 4: cat4++; if (max < cat4) { max = cat4; } break;
                case 5: cat5++; if (max < cat5) { max = cat5; } break;
                case 6: cat6++; if (max < cat6) { max = cat6; } break;
                case 7: cat7++; if (max < cat7) { max = cat7; } break;
                case 8: cat8++; if (max < cat8) { max = cat8; } break;
                case 9: cat9++; if (max < cat9) { max = cat9; } break;
                case 10: cat10++; if (max < cat10) { max = cat10; } break;
            }
        }
        if (max == cat1)
        {
            Console.WriteLine(1);
        }
        if (max == cat2 && max != cat1)
        {
            Console.WriteLine(2);
        }
        if (max == cat3 && max != cat1 && max != cat2)
        {
            Console.WriteLine(3);
        }
        if (max == cat4 && max != cat1 && max != cat2 && max != cat3)
        {
            Console.WriteLine(4);
        }
        if (max == cat5 && max != cat1 && max != cat2 && max != cat3 && max != cat4)
        {
            Console.WriteLine(5);
        }
        if (max == cat6 && max != cat1 && max != cat2 && max != cat3 && max != cat4 && max != cat5)
        {
            Console.WriteLine(6);
        }
        if (max == cat7 && max != cat1 && max != cat2 && max != cat3 && max != cat4 && max != cat5 && max != cat6)
        {
            Console.WriteLine(7);
        }
        if (max == cat8 && max != cat1 && max != cat2 && max != cat3 && max != cat4 && max != cat5 && max != cat6
            && max != cat7)
        {
            Console.WriteLine(8);
        }
        if (max == cat9 && max != cat1 && max != cat2 && max != cat3 && max != cat4 && max != cat5 && max != cat6
           && max != cat7 && max != cat8)
        {
            Console.WriteLine(9);
        }
        if (max == cat10 && max != cat1 && max != cat2 && max != cat3 && max != cat4 && max != cat5 && max != cat6
           && max != cat7 && max != cat8 && max != cat9)
        {
            Console.WriteLine(10);
        }
    }
}

