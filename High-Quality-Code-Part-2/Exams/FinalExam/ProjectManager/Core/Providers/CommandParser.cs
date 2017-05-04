namespace ProjectManager.CLI.Core.Providers
{
    using System.Linq;
    using Commands;
    using Common;
    using Contracts;

    public class CommandParser : IParser
    {
        private const string NoCommandMessage = "No command has been provided!";
        private CommandsFactory factory;

        public CommandParser(CommandsFactory factory)
        {
            this.factory = factory;
        }

        public string ProcessCommand(string fullCommandName)
        {
            var commandName = fullCommandName.Split(' ')[0];

            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new UserValidationException(NoCommandMessage);
            }

            var command = this.factory.CreateCommandFromString(commandName);
            var commandParameters = fullCommandName.Split(' ').Skip(1).ToList();

            return command.Execute(commandParameters);
        }
    }
}
