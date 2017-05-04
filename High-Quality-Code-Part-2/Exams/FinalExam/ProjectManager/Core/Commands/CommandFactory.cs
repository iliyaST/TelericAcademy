using System;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using Pesho.Core.Commands;

namespace ProjectManager.Commands
{
    public class CommandFactory
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
                case "createproject": return new CreateProjectCommand(database, factory);
                case "createuser": return new CreateUserCommand();
                case "createtask": return new CreateTaskCommand();
                case "listprojects": return new ListProjectsCommand(database);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }      

        private string FindCommandName(string parameters)
        {
            var command = string.Empty;
            var end = DateTime.Now + TimeSpan.FromSeconds(1);

            // TODO: Bottleneck?
            while (DateTime.Now < end);

            for (int i = 0; i < parameters.Length; i++)
            {
                command += parameters[i].ToString().ToLower();
            }           

            return command;
        }               
    }
}

