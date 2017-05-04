namespace ProjectManager.Common
{
    using System.Linq;
    using Commands;

    public class CommandProcessor
    {
        private const string NoCommandMessage = "No command has been provided!";
        private CommandFactory factory;

        public CommandProcessor(CommandFactory factory)
        {
            this.factory = factory;
        }

        public string ProcessCommand(string fullCommandName)
        {
            var commandName = fullCommandName.Split(' ')[0];

            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new Exceptions.UserValidationException(NoCommandMessage);
            }

            var command = this.factory.CreateCommandFromString(commandName);
            var commandParameters = fullCommandName.Split(' ').Skip(1).ToList();

            return command.Execute(commandParameters);
        }
    }
}
