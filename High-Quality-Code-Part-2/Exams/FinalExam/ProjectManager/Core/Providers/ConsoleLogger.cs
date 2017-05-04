using System;
using Pesho.Core.Contracts;

namespace Pesho.Core.Providers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
