using System;

class FighterAttack
{
    static void Main()
    {
        int pX1 = int.Parse(Console.ReadLine());
        int pY1 = int.Parse(Console.ReadLine());
        int pX2 = int.Parse(Console.ReadLine());
        int pY2 = int.Parse(Console.ReadLine());
        int fX = int.Parse(Console.ReadLine());
        int fY = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());
        int totalDamage = 0;
        if (pX1 > pX2)
        {
            int temp = pX2;
            pX2 = pX1;
            pX1 = temp;
        }
        if (pY1 < pY2)
        {
            int temp = pY2;
            pY2 = pY1;
            pY1 = temp;
        }
        /* 2 3 6 5 -6 4 10 */

        if ((fX + D >= pX1 && fX + D <= pX2) && (fY <= pY1 && fY >= pY2))
        {
            totalDamage += 100;
        }
        if (fX + D + 1 >= pX1 && fX + D + 1 <= pX2)
        {
            totalDamage += 75;
        }
        if ((fY + 1 >= pY2 && fY + 1 <= pY1) && (fX + D >= pX1 && fX + D <= pX2))
        {
            totalDamage += 50;
        }
        if (fY - 1 >= pY2 && fY - 1 <= pY1 && (fX + D >= pX1 && fX + D <= pX2))
        {
            totalDamage += 50;
        }

        Console.WriteLine(totalDamage + "%");
    }
}

