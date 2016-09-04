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
        int[] value = new int[5];
        int[] value1 = new int[5];
        int value1Counter = 0;
        int min = int.MaxValue;

        for (int i = 0; i < 5; i++)
        {
            string temp = Console.ReadLine();
            if (temp == "10")
            {
                temp = "+";
                value[i] = 10;
                hand += temp;
                continue;
            }
            if (temp == "J")
            {
                value[i] = 11;
                hand += temp;
                continue;
            }
            if (temp == "Q")
            {
                value[i] = 12;
                hand += temp;
                continue;               
            }
            if (temp == "K")
            {
                value[i] = 13;
                hand += temp;
                continue;              
            }
            if (temp == "A")
            {
                value[i] = 14;
                hand += temp;
                continue;              
            }
            value[i] = Convert.ToInt32(temp);
            hand += temp;
        }

        string card1 = hand[0].ToString();
        string card2 = hand[1].ToString();
        string card3 = hand[2].ToString();
        string card4 = hand[3].ToString();
        string card5 = hand[4].ToString();

        for (int i = 0; i < 5; i++)
        {
            if (hand[i].ToString() == card1)
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
        string b = a.Replace(card2, "$");

        for (int i = 0; i < 5; i++)
        {
            if (card3 == b[i].ToString())
            {
                counter3++;
            }
        }
        string c = b.Replace(card3, "@");
        for (int i = 0; i < 5; i++)
        {
            if (card4 == c[i].ToString())
            {
                counter4++;
                hand.Replace('%', hand[i]);
            }
        }

        string d = c.Replace(card4, "%");
        for (int i = 0; i < 5; i++)
        {
            if (card5 == d[i].ToString())
            {
                counter5++;
                hand.Replace('&', hand[i]);
            }
        }


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
        else if (counter1 == 1 && counter2 == 1 && counter3 == 1 && counter4 == 1 && counter5 == 1)
        {
            if (value[0] + value[1] + value[2] + value[3] + value[4] < 60)
            {               
                for (int i = 0; i < 5; i++)
                {
                    value1[i] = value[i];
                    if (value[i] == 14)
                    {
                        value1[i] = value[i] - 13;
                    }
                }                
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    value1[i] = value[i];                  
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if(min>value1[i])
                {
                    min = value1[i];
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if(value1[i]==min+1)
                {
                    min++;
                    value1Counter++;
                    i = -1;
                }
            }          
            if(value1Counter==4)
            {
                Console.WriteLine("Straight");
            } 
            else
            {
                Console.WriteLine("Nothing");
            }
        }       
    }
}

