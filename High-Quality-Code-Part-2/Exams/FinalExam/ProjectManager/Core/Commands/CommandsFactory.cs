using Pesho.Core.Contracts;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands.Contracts;
using ProjectManager.CLI.Data.Contracts;

namespace ProjectManager.CLI.Core.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private IDatabase database;
        private IModelsFactory factory;

        public CommandsFactory(IDatabase database, IModelsFactory factory)
        {
            this.database = database;
            this.factory = factory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            commandName = commandName.ToLower();

            switch (commandName)
            {
                case "createproject": return new CreateProjectCommand(this.database, this.factory);
                case "createuser": return new CreateUserCommand(this.database, this.factory);
                case "createtask": return new CreateTaskCommand(this.database, this.factory);
                case "listprojects": return new ListProjectsCommand(this.database);
                case "listprojectdetails": return new ListProjectDetails(this.database);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }
    }
}