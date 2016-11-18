using System;

class EnterNumbers
{
    static void ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());

        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException(string.Format("The number : {0} is not in range ({1} , {2})", number, start, end));
        }
    }

    static void Main()
    {
        int start = 1;
        int end = 100;

        for (int i = 0; i < 10; i++)
        {
            try
            {
                ReadNumber(start, end);
            }
            catch (ArgumentOutOfRangeException AE)
            {
                Console.WriteLine(AE.Message);
                Console.WriteLine("Enter another number:");
                i = i - 1;
            }          
        }

        Console.WriteLine("You have sucssesfully completed the task, Good bye!");
    }
}

