namespace SchoolSystem.CLI.Core.Contracts
{
    using System.Collections.Generic;
    using Commands.Contracts;

    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> GetCommandParameters(string commandName);
    }
}
