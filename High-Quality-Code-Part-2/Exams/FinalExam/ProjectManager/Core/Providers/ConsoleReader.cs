using System;
using Pesho.Core.Contracts;

namespace Pesho.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
