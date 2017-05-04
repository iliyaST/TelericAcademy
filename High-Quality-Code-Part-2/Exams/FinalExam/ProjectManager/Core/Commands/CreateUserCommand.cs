using Bytes2you.Validation;
using Pesho.Core.Contracts;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands.Contracts;
using ProjectManager.CLI.Data;
using ProjectManager.CLI.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.CLI.Core.Commands
{
    public class CreateUserCommand : ICommand
    {
        private const string InvalidParametersMessage = "Invalid command parameters count!";
        private const string EmptyParameterMessage = "Some of the passed parameters are empty!";
        private const string UserAlreadyExist = "A user with that username already exists!";
        private const string SuccesfullyAddedUser = "Successfully created a new user!";

        private const int MaxParametersCount = 3;

        private IDatabase database;
        private IModelsFactory factory;

        public CreateUserCommand(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();
            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory")
                .IsNull()
                .Throw();

            this.database = database;
            this.factory = factory;
        }

        public string Execute(List<string> commandParameters)
        {
            var database = new Database();

            var factory = new ModelsFactory();

            if (commandParameters.Count != MaxParametersCount)
            {
                throw new UserValidationException(InvalidParametersMessage);
            }

            if (commandParameters.Any(parameter => parameter == string.Empty))
            {
                throw new UserValidationException(EmptyParameterMessage);
            }

            var projectId = int.Parse(commandParameters[0]);
            var username = commandParameters[1];
            var userEmail = commandParameters[2];

            if (database.Projects[projectId].Users.Any() && database.Projects[projectId].Users.Any(user => user.UserName == username))
            {
                throw new UserValidationException(UserAlreadyExist);
            }

            database.Projects[projectId].Users.Add(factory.CreateUser(username, userEmail));

            return SuccesfullyAddedUser;
        }
    }
}
