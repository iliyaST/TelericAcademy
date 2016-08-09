using System;

class DrunkenNumbers
{
    static void Main()
    {
        int numberOfRounds = int.Parse(Console.ReadLine());
        int counterM = 0;
        int counterV = 0;

        for (int i = 0; i < numberOfRounds; i++)
        {
            long tempNumber = long.Parse(Console.ReadLine());
            int basicCounter = 1;
            foreach (var digit in tempNumber.ToString())
            {
                if (tempNumber.ToString().Length / 2 != 0)
                {
                    if (basicCounter == ((tempNumber.ToString().Length + 1) / 2))
                    {                      
                        basicCounter++;
                        continue;
                    }
                    if (basicCounter > ((tempNumber.ToString().Length + 1) / 2))
                    {
                        counterV += digit - '0';
                        continue;
                    }
                    counterM += digit - '0';
                    basicCounter++;
                }
                else
                {
                    if (basicCounter >= (tempNumber.ToString().Length / 2) + 1)
                    {
                        counterV += digit - '0';
                        continue;
                    }
                    counterM += digit - '0';
                    basicCounter++;
                }
            }
        }

        if (counterM > counterV)
        {
            Console.WriteLine("M {0}", counterM - counterV);
        }
        if (counterM < counterV)
        {
            Console.WriteLine("V {0}", counterV - counterM);
        }
        if (counterM == counterV)
        {
            Console.WriteLine("No {0}", counterV + counterM);
        }
    }
}


