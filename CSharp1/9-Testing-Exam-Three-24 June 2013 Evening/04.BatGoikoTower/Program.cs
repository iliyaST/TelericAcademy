using System;

class BatGoikoTower
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int counter = 0;
        int MinusesCounter = 0;
        int helpCounter = 0;
        int helpMinusCounter = 0;
       
        //top of pyramid
        Console.Write(new string('.', n - 1));
        Console.Write(new string('/', 1));
        Console.Write(new string('\\', 1));
        Console.WriteLine(new string('.', n - 1));
        Console.Write(new string('.', n - 2));
        Console.Write(new string('/', 1));
        Console.Write(new string('-', 2));
        Console.Write(new string('\\', 1));
        Console.WriteLine(new string('.', n - 2));
        //bottom of pyramid
        for (int i = 0; i < n - 2; i++)
        {   
            if (i == 1 + counter)
            {
                Console.Write(new string('.', (((n * 2 - (6 + MinusesCounter))) - 2) / 2));
                Console.Write(new string('/', 1));
                Console.Write(new string('-', 6 + MinusesCounter));
                Console.Write(new string('\\', 1));
                Console.WriteLine(new string('.', (((n * 2 - (6 + MinusesCounter))) - 2) / 2));
                counter += 3 + helpCounter;
                helpCounter++;
                MinusesCounter += 6 + helpMinusCounter;
                helpMinusCounter += 2;
            }
            else
            {
                Console.Write(new string('.', n - 3 - i));
                Console.Write(new string('/', 1));
                Console.Write(new string('.',((((n*2)-((n-3-i)*2))-2))));
                Console.Write(new string('\\', 1));
                Console.WriteLine(new string('.', n - 3 - i));
            }
        }
    }
}

