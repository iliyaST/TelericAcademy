using System;
using ProjectManager.CLI.Core.Conctracts;

namespace ProjectManager.CLI.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
