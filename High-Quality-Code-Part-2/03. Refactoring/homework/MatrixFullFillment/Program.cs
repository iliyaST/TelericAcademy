namespace MatrixFullFillment
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a number!");

            string input = Console.ReadLine();
            var logger = new ConsoleLogger();

            var engine = new Engine(input, logger);

            engine.Execute();
        }
    }
}
