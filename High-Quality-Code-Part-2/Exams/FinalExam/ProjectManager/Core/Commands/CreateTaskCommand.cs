using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public sealed class CreateTaskCommand : ICommand
    {
        private const string InvalidParameters = "Invalid command parameters count!";
        private const string EmptyParameter = "Some of the passed parameters are empty!";
        private const string SuccesfullyCreated = "Successfully created a new task!";

        private const int MaxCountParameters = 4;

        public string Execute(List<string> commandParameters)
        {
            var database = new Database();

            var factory = new ModelsFactory();

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

            var project = database.Projects[projectId];

            var owner = project.Users[userId];

            var task = factory.CreateTask(owner, projectName, projectState);
            project.Tasks.Add(task);

            return SuccesfullyCreated;
        }
    }
}
