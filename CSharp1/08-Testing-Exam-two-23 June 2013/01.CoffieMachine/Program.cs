using System;

class CoffieMachine
{
    static void Main()
    {
        int N1 = int.Parse(Console.ReadLine());
        int N2 = int.Parse(Console.ReadLine());
        int N3 = int.Parse(Console.ReadLine());
        int N4 = int.Parse(Console.ReadLine());
        int N5 = int.Parse(Console.ReadLine());
        double amountMoneyInMachine = N1 * 0.05 + N2 * 0.10 + N3 * 0.20 + N4 * 0.50 + N5 * 1.00;
        double amountOfMoney = double.Parse(Console.ReadLine());
        double priceOfDrink = double.Parse(Console.ReadLine());

        if (amountOfMoney >= priceOfDrink)
        {
            double change = amountOfMoney - priceOfDrink;
            if (amountMoneyInMachine >= change)
            {
                Console.WriteLine("Yes {0:0.00}", amountMoneyInMachine - change);
            }
            else
            {
                double p = change - amountMoneyInMachine;
                Console.WriteLine("No {0:0.00}", p);
            }

        }
        else
        {
            Console.WriteLine("More {0:0.00}", priceOfDrink - amountOfMoney);
        }

    }
}

