using System;

class SolveTasks
{

    static void ReverseTheNumber(string number)
    {
        string reversed = "";

        for (int i = number.Length - 1; i >= 0; i--)
        {
            reversed += number[i];
        }

        Console.WriteLine("The reversed number is:" + reversed);
        
    }

    static void Average(int[] array)
    {
        double average = 0;

        for (int i = 0; i < array.Length; i++)
        {
            average += array[i];
        }

        average /= array.Length;

        Console.WriteLine("The average from the integers is:"+average);
        
    }

    static void LinearEquation(int a, int x, int b)
    {
        int result = 0;

        result = a * x + b;

        Console.WriteLine("Result of Linear equation is:"+result);
        
    }


    static void Main()
    {
        Console.WriteLine("Chose one of the following options:");
        Console.WriteLine("1:(Reverse a Number)   2:(See Average of Sequince of integers) 3:LinearE");
        Console.WriteLine("Press 4 to exit");
        while (true)
        {
            Console.WriteLine("Enter Option");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.WriteLine("Insert a number to reverse");
                string number = Console.ReadLine();
                Console.WriteLine("Reversed number is:");
                ReverseTheNumber(number);
            }
            else if (option == 2)
            {
                Console.WriteLine("Insert a sequince of integers divided with space");
                string[] arrayOfIntegers = Console.ReadLine().Split(new char[] { ' ' });
                int[] array = new int[arrayOfIntegers.Length];

                for (int i = 0; i < arrayOfIntegers.Length; i++)
                {
                    array[i] = int.Parse(arrayOfIntegers[i]);
                }

                Average(array);
            }
            else if (option == 3)
            {
                Console.WriteLine("Enter a, x and b:");
                int a = int.Parse(Console.ReadLine());
                int x = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());

                LinearEquation(a, x, b);
            }
            else if(option==4)
            {
                Console.WriteLine("Congratolations! You have completed the task!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input Try Again!");
            }
        }
    }
}

