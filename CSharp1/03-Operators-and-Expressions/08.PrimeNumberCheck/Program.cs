using System;
/*
Problem 8. Prime Number Check
Write an expression that checks if given positive integer number n (n ≤ 100) is prime 
(i.e. it is divisible without remainder only to itself and 1).
Note: You should check if the number is positive
*/
class PrimeNumberCheck
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string result;
        int b = 0;
        for (int i = 2; i < n; i++)
        {
            bool isPrimeOrNot = n % i == 0;
            result = isPrimeOrNot.ToString().ToLower();
            if (result == "true")
            {
                Console.WriteLine("false");
                break;
            }
            b++;
        }
        if (b == n - 2)
        {
            Console.WriteLine("true");
        }
        if (n <= 1)
        {
            Console.WriteLine("false");
        }
    }
}

