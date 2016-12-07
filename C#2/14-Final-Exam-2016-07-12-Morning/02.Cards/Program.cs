using System;

class Cards
{
    static void Main()
    {
        int numberOfHands = int.Parse(Console.ReadLine());

        int[] values = new int[52];


        for (int i = 0; i < numberOfHands; i++)
        {
            long currentHand = long.Parse(Console.ReadLine());

            for (int p = 0; p < 52; p++)
            {
                long mask = (long)1 << p;
                long nAndMask = currentHand & mask;
                long bit = nAndMask >> p;

                if (bit == 1)
                {
                    values[p]++;
                }
            }          
        }


        int counter = 0;

        for (int i = values.Length-1; i >= 0; i--)
        {
            if (values[i] == 0)
            {
                Console.WriteLine("Wa wa!");
                break;
            }

            if (values[i] > 0)
            {
                counter++;
                if (counter == 52)
                {
                    Console.WriteLine("Full deck");
                    break;
                }
            }
        }

        string g = "cdhs";
        int cardIndex = 2;
        char ch = 'c';
        int b = 0;
        int other = 0;

        for (int i = 0; i < values.Length; i++)
        {

            if (values[i] % 2 == 0)
            {
                if (cardIndex > 9)
                {
                    switch (cardIndex)
                    {
                        case 10: Console.Write("T{0} ", ch); break;
                        case 11: Console.Write("J{0} ", ch); break;
                        case 12: Console.Write("Q{0} ", ch); break;
                        case 13: Console.Write("K{0} ", ch); break;
                        case 14: Console.Write("A{0} ", ch); break;
                    }
                }
                else
                {
                    Console.Write("{0}{1} ", cardIndex, ch);
                }
            }

            cardIndex++;

            if (i < 51 && cardIndex > 14)
            {
                cardIndex = 2;
                other++;
                ch = g[other];
            }
            b++;
        }
    }
}