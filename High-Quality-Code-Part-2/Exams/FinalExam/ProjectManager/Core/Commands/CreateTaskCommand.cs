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
    public sealed class CreateTaskCommand : ICommand
    {
        private const string InvalidParameters = "Invalid command parameters count!";
        private const string EmptyParameter = "Some of the passed parameters are empty!";
        private const string SuccesfullyCreated = "Successfully created a new task!";

        private const int MaxCountParameters = 4;

        private IDatabase database;
        private IModelsFactory factory;

        public CreateTaskCommand(IDatabase database, IModelsFactory factory)
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
            if (commandParameters.Count != MaxCountParameters)
            {
                throw new UserValidationException(InvalidParameters);
            }

            if (commandParameters.Any(parameter => parameter == string.Empty))
            {
                throw new UserValidationException(EmptyParameter);
            }

            var projectId = int.Parse(commandParameters[0]);
            var userId = int.Parse(commandParameters[1]);
            var projectName = commandParameters[2];
            var projectState = commandParameters[3];

            var project = this.database.Projects[projectId];

            var owner = project.Users[userId];

            var task = this.factory.CreateTask(owner, projectName, projectState);
            project.Tasks.Add(task);

            return SuccesfullyCreated;
        }
    }
}
