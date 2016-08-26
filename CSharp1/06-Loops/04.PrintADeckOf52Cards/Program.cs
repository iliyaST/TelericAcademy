using System;
/*
Problem 4. Print a Deck of 52 Cards
Write a program that generates and prints all possible cards 
from a standard deck of 52 cards (without the jokers). 
The cards should be printed using the classical notation 
(like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
The card faces should start from 2 to A.
Print each card face in its four possible suits: clubs, 
diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.
*/
class PrintADeck
{
    static void Main()
    {
        string card = Console.ReadLine();
        int counter = 0;

        switch (card)
        {
            case "2":
                {
                    counter = 2;
                    break;
                }
            case "3":
                {
                    counter = 3;
                    break;
                }
            case "4":
                {
                    counter = 4;
                    break;
                }
            case "5":
                {
                    counter = 5;
                    break;
                }
            case "6":
                {
                    counter = 6;
                    break;
                }
            case "7":
                {
                    counter = 7;
                    break;
                }
            case "8":
                {
                    counter = 8;
                    break;
                }
            case "9":
                {
                    counter = 9;
                    break;
                }
            case "10":
                {
                    counter = 10;
                    break;
                }
            case "J":
                {
                    counter = 11;
                    break;
                }
            case "Q":
                {
                    counter = 12;
                    break;
                }
            case "K":
                {
                    counter = 13;
                    break;
                }
            case "A":
                {
                    counter = 14;
                    break;
                }
        }
        for (int i = 2; i <= counter; i++)
        {
            Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", i);
            if (i == 10)
            {
                if (counter >= 11)
                {
                    Console.WriteLine("J of spades, J of clubs, J of hearts, J of diamonds");
                }
                if (counter >= 12)
                {
                    Console.WriteLine("Q of spades, Q of clubs, Q of hearts, Q of diamonds");
                }
                if (counter >= 13)
                {
                    Console.WriteLine("K of spades, K of clubs, K of hearts, K of diamonds");
                }
                if (counter == 14)
                {
                    Console.WriteLine("A of spades, A of clubs, A of hearts, A of diamonds");
                }
                break;
            }
        }
    }
}




