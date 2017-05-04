using ProjectManager.CLI.Core.Contracts;
using System;

namespace ProjectManager.CLI.Core.Providers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
