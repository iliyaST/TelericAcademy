using Pesho.Core.Commands;
using Pesho.Core.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Commands
{
    public class CommandFactory : IFactory
    {
        private Database database;
        private ModelsFactory factory;

        public CommandFactory(Database database, ModelsFactory factory)
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
                case "createuser": return new CreateUserCommand();
                case "createtask": return new CreateTaskCommand();
                case "listprojects": return new ListProjectsCommand(this.database);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }              
    }
}