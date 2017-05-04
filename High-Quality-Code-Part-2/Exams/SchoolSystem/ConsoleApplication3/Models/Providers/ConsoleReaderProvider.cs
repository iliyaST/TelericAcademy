namespace School.Models.Providers
{
    using System;
    using Contracts;

    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
