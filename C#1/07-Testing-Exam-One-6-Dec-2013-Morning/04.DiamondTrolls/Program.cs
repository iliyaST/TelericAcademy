using System;

class DiamondTrolls
{
    static void Main()
    {
        int sizeOfDiamond = int.Parse(Console.ReadLine());
        int widthOfDiamond = sizeOfDiamond * 2 + 1;
        int heightOfDiamond = (6 + (((sizeOfDiamond - 3) / 2) * 3));
        int counter = 1;
        int counter1 = 0;
        int counter3 = 1;
        int counter4 = 2;

        for (int i = 0; i < heightOfDiamond; i++)
        {
            for (int j = 0; j < widthOfDiamond; j++)
            {
                if (i > 0 && i < heightOfDiamond - sizeOfDiamond - 1)
                {
                    if (j == widthOfDiamond / 2 - sizeOfDiamond / 2 - counter)
                    {
                        Console.Write("*");
                        counter++;
                        continue;
                    }
                    if (j == widthOfDiamond / 2 + sizeOfDiamond / 2 + counter1)
                    {
                        Console.Write("*");
                        continue;
                    }
                }
                if (i == 0)
                {
                    if (j >= widthOfDiamond / 2 - sizeOfDiamond / 2 && j <= widthOfDiamond / 2 - sizeOfDiamond / 2 + sizeOfDiamond - 1)
                    {
                        Console.Write("*");
                        continue;
                    }
                }
                if (j == widthOfDiamond / 2)
                {
                    Console.Write("*");
                    continue;
                }
                if (i == heightOfDiamond - 2)
                {
                    if (j >= widthOfDiamond / 2 - 1 && j <= widthOfDiamond / 2 + 1)
                    {
                        Console.Write("*");
                        continue;
                    }
                }
                if (i == heightOfDiamond - sizeOfDiamond - 1)
                {
                    Console.Write("*");
                    continue;
                }
                if (i > heightOfDiamond - sizeOfDiamond - 1 && i < heightOfDiamond - 2)
                {
                    if (j == counter3)
                    {
                        Console.Write("*");
                        continue;
                    }
                    if (j == widthOfDiamond - counter4)
                    {
                        Console.Write("*");
                        continue;
                    }
                }
                Console.Write(".");
            }
            if (i > heightOfDiamond - sizeOfDiamond - 1 && i < heightOfDiamond - 2)
            {
                counter3++;
                counter4++;
            }
            counter1++;
            Console.WriteLine();
        }

    }
}

