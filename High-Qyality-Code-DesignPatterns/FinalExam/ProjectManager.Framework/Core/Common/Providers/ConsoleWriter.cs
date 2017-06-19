using System;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
