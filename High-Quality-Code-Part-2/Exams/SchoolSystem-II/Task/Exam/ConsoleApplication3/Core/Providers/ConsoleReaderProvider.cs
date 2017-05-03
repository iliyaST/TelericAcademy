namespace SchoolSystem.CLI.Core.Providers
{
    using System;
    using Core.Contracts;

    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
