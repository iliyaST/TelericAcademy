using System;

class Poker
{
    static void Main()
    {
        string hand = "";
        int counter1 = 0;
        int counter2 = 0;
        int counter3 = 0;
        int counter4 = 0;
        int counter5 = 0;

        for (int i = 0; i < 5; i++)
        {
            string temp = Console.ReadLine();
            hand += temp;
        }
        string card1 = hand[0].ToString();
        string card2 = hand[1].ToString();
        string card3 = hand[2].ToString();
        string card4 = hand[3].ToString();
        string card5 = hand[4].ToString();

        for (int i = 0; i < 5; i++)
        {
            if (hand[i].ToString()==card1)
            {
                counter1++;
            }          
        }
        string a = hand.Replace(card1, "*"); 

        for (int i = 0; i < 5; i++)
        {
            if (card2 == a[i].ToString())
            {
                counter2++;
            }          
        }
        string b = hand.Replace(card2,"$");

        for (int i = 0; i < 5; i++)
        {
            if (card3 == b[i].ToString())
            {
                counter3++;
            }
        }
        string c = hand.Replace(card3, "@");
        for (int i = 0; i < 5; i++)
        {
            if (card4 == c[i].ToString())
            {
                counter4++;
                hand.Replace('%', hand[i]);
            }
        }
        string d = hand.Replace(card4, "%");
        for (int i = 0; i < 5; i++)
        {
            if (card4 == hand[i].ToString())
            {
                counter5++;
                hand.Replace('&',hand[i]);
            }
        }
        string e = hand.Replace(card4, "&");
        

        if (counter1 == 5 || counter2 == 5 || counter3 == 5 || counter4 == 5 || counter5 == 5)
        {
            Console.WriteLine("Impossible");
        }
        else if (counter1 == 4 || counter2 == 4 || counter3 == 4 || counter4 == 4 || counter5 == 4)
        {
            Console.WriteLine("Four of a Kind");
        }
        else if (counter1 == 3 || counter2 == 3 || counter3 == 3 || counter4 == 3 || counter5 == 3)
        {
            if (counter1 != 2 && counter2 != 2 && counter3 != 2 && counter4 != 2 && counter5 != 2)
            {
                Console.WriteLine("Three of a Kind");
            }
            else
            {
                Console.WriteLine("Full House");
            }
        }
        else if (counter1 == 2 || counter2 == 2 || counter3 == 2 || counter4 == 2 || counter5 == 2)
        {
            if ((counter1 == 2 && counter2 != 2 && counter3 != 2 && counter4 != 2 && counter5 != 2) ||
                (counter2 == 2 && counter1 != 2 && counter3 != 2 && counter4 != 2 && counter5 != 2)
                || (counter3 == 2 && counter1 != 2 && counter2 != 2 && counter4 != 2 && counter5 != 2)
                || (counter4 == 2 && counter1 != 2 && counter2 != 2 && counter3 != 2 && counter5 != 2)
                || (counter5 == 2 && counter1 != 2 && counter2 != 2 && counter3 != 2 && counter4 != 2))
            {
                Console.WriteLine("One Pair");
            }
            else
            {
                Console.WriteLine("Two Pairs");
            }
        }
        else
        {
            Console.WriteLine("Nothing");
        }


    }
}

