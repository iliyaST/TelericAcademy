namespace ConsoleApplication3.Models.Providers
{
    using System;
    using Contracts;

    public class ConsoleWriterProvider : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
