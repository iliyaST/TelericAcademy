using System;
/*
Problem 3. Check for a Play Card
Classical play cards use the following signs to designate the card face: `
2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints
“yes” if it is a valid card sign or “no” otherwise. Examples:
*/
class CheckPlayCard
{
    static void Main()
    {
        string card = Console.ReadLine();

        switch (card)
        {
            case "2":
                Console.WriteLine("yes " + card);
                break;
            case "3":
                Console.WriteLine("yes " + card);
                break;
            case "4":
                Console.WriteLine("yes " + card);
                break;
            case "5":
                Console.WriteLine("yes " + card);
                break;
            case "6":
                Console.WriteLine("yes " + card);
                break;
            case "7":
                Console.WriteLine("yes " + card);
                break;
            case "8":
                Console.WriteLine("yes " + card);
                break;
            case "9":
                Console.WriteLine("yes " + card);
                break;
            case "10":
                Console.WriteLine("yes " + card);
                break;
            case "J":
                Console.WriteLine("yes " + card);
                break;
            case "Q":
                Console.WriteLine("yes " + card);
                break;
            case "K":
                Console.WriteLine("yes " + card);
                break;
            case "A":
                Console.WriteLine("yes " + card);
                break;
            default:
                Console.WriteLine("no " + card);
                break;
        }
    }
}

